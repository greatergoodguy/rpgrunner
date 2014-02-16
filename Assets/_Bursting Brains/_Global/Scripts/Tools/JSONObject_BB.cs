#define PRETTY		//Comment out when you no longer need to read JSON to disable pretty print system-wide
 
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
/*
 * http://www.opensource.org/licenses/lgpl-2.1.php
 * JSONObject class
 * for use with Unity
 * Copyright Matt Schoen 2010 - 2013
 */
 
public class JSONObject_BB {
	const int MAX_DEPTH = 1000;
	const string INFINITY = "\"INFINITY\"";
	const string NEGINFINITY = "\"NEGINFINITY\"";
	const string NaN = "\"NaN\"";
	public static char[]  WHITESPACE = new char[] { ' ', '\r', '\n', '\t' };
	public enum Type { NULL, STRING, NUMBER, OBJECT, ARRAY, BOOL }
	public bool isContainer { get { return (type == Type.ARRAY || type == Type.OBJECT); } }
	public JSONObject_BB parent;
	public Type type = Type.NULL;
	public int Count { 
		get { 
			if(list == null)
				return -1;
			return list.Count; 
		} 
	}
	//TODO: Switch to list
	public List<JSONObject_BB> list;
	public List<string> keys;
	public string str;

	public long n;
	public long f {
		get {
			return n;
		}
	}

	public bool b;
	public delegate void AddJSONConents(JSONObject_BB self);
 
	public static JSONObject_BB nullJO { get { return new JSONObject_BB(JSONObject_BB.Type.NULL); } }	//an empty, null object
	public static JSONObject_BB obj { get { return new JSONObject_BB(JSONObject_BB.Type.OBJECT); } }		//an empty object
	public static JSONObject_BB arr { get { return new JSONObject_BB(JSONObject_BB.Type.ARRAY); } }		//an empty array
 
	public JSONObject_BB(JSONObject_BB.Type t) {
		type = t;
		switch(t) {
			case Type.ARRAY:
				list = new List<JSONObject_BB>();
				break;
			case Type.OBJECT:
				list = new List<JSONObject_BB>();
				keys = new List<string>();
				break;
		}
	}
	public JSONObject_BB(bool b) {
		type = Type.BOOL;
		this.b = b;
	}
	public JSONObject_BB(long l) {
		type = Type.NUMBER;
		this.n = l;
	}
	public JSONObject_BB(Dictionary<string, string> dic) {
		type = Type.OBJECT;
		keys = new List<string>();
		list = new List<JSONObject_BB>();
		foreach(KeyValuePair<string, string> kvp in dic) {
			keys.Add(kvp.Key);
			list.Add(new JSONObject_BB { type = Type.STRING, str = kvp.Value });
		}
	}
	public JSONObject_BB(Dictionary<string, JSONObject_BB> dic) {
		type = Type.OBJECT;
		keys = new List<string>();
		list = new List<JSONObject_BB>();
		foreach(KeyValuePair<string, JSONObject_BB> kvp in dic) {
			keys.Add(kvp.Key);
			list.Add(kvp.Value);
		}
	}
	public JSONObject_BB(AddJSONConents content) {
		content.Invoke(this);
	}
	public JSONObject_BB(JSONObject_BB[] objs) {
		type = Type.ARRAY;
		list = new List<JSONObject_BB>(objs);
	}
	//Convenience function for creating a JSONObject containing a string.  This is not part of the constructor so that malformed JSON data doesn't just turn into a string object
	public static JSONObject_BB StringObject(string val) { return new JSONObject_BB { type = JSONObject_BB.Type.STRING, str = val }; }
	public void Absorb(JSONObject_BB obj) {
		list.AddRange(obj.list);
		keys.AddRange(obj.keys);
		str = obj.str;
		n = obj.n;
		b = obj.b;
		type = obj.type;
	}
	public JSONObject_BB() { }
	#region PARSE
	public JSONObject_BB(string str, bool strict = false) {	//create a new JSONObject from a string (this will also create any children, and parse the whole string)
		if(str != null) {
			str = str.Trim(WHITESPACE);
			if(strict) {
				if(str[0] != '[' && str[0] != '{') {
					type = Type.NULL;
					Debug.LogWarning("Improper (strict) JSON formatting.  First character must be [ or {");
					return;
				}
			}
			if(str.Length > 0) {
				if(string.Compare(str, "true", true) == 0) {
					type = Type.BOOL;
					b = true;
				} else if(string.Compare(str, "false", true) == 0) {
					type = Type.BOOL;
					b = false;
				} else if(string.Compare(str, "null", true) == 0) {
					type = Type.NULL;

				} else if(str == INFINITY) {
					type = Type.NUMBER;
					n = long.MaxValue;
				} else if(str == NEGINFINITY) {
					type = Type.NUMBER;
					n = long.MinValue;
				} else if(str == NaN) {
					type = Type.NUMBER;
					n = 0;

				} else if(str[0] == '"') {
					type = Type.STRING;
					this.str = str.Substring(1, str.Length - 2);
				} else {
					try {

						n = System.Convert.ToInt64(str);				 

						type = Type.NUMBER;
					} catch(System.FormatException) {
						int token_tmp = 1;
						/*
						 * Checking for the following formatting (www.json.org)
						 * object - {"field1":value,"field2":value}
						 * array - [value,value,value]
						 * value - string	- "string"
						 *		 - number	- 0.0
						 *		 - bool		- true -or- false
						 *		 - null		- null
						 */
						int offset = 0;
						switch(str[offset]) {
							case '{':
								type = Type.OBJECT;
								keys = new List<string>();
								list = new List<JSONObject_BB>();
								break;
							case '[':
								type = JSONObject_BB.Type.ARRAY;
								list = new List<JSONObject_BB>();
								break;
							default:
								type = Type.NULL;
								Debug.LogWarning("improper JSON formatting:" + str);
								return;
						}
						string propName = "";
						bool openQuote = false;
						bool inProp = false;
						int depth = 0;
						while(++offset < str.Length) {
							if(System.Array.IndexOf<char>(WHITESPACE, str[offset]) > -1)
								continue;
							if(str[offset] == '\"') {
								if(openQuote) {
									if(!inProp && depth == 0 && type == Type.OBJECT)
										propName = str.Substring(token_tmp + 1, offset - token_tmp - 1);
									openQuote = false;
								} else {
									if(depth == 0 && type == Type.OBJECT)
										token_tmp = offset;
									openQuote = true;
								}
							}
							if(openQuote)
								continue;
							if(type == Type.OBJECT && depth == 0) {
								if(str[offset] == ':') {
									token_tmp = offset + 1;
									inProp = true;
								}
							}
 
							if(str[offset] == '[' || str[offset] == '{') {
								depth++;
							} else if(str[offset] == ']' || str[offset] == '}') {
								depth--;
							}
							//if  (encounter a ',' at top level)  || a closing ]/}
							if((str[offset] == ',' && depth == 0) || depth <  0) {
								inProp = false;
								string inner = str.Substring(token_tmp, offset - token_tmp).Trim(WHITESPACE);
								if(inner.Length > 0) {
									if(type == Type.OBJECT)
										keys.Add(propName);
									list.Add(new JSONObject_BB(inner));
								}
								token_tmp = offset + 1;
							}
						}
					}
				}
			} else type = Type.NULL;
		} else type = Type.NULL;	//If the string is missing, this is a null
	}
	#endregion
	public bool IsNumber { get { return type == Type.NUMBER; } }
	public bool IsNull { get { return type == Type.NULL; } }
	public bool IsString { get { return type == Type.STRING; } }
	public bool IsBool { get { return type == Type.BOOL; } }
	public bool IsArray { get { return type == Type.ARRAY; } }
	public bool IsObject { get { return type == Type.OBJECT; } }
	public void Add(bool val) { Add(new JSONObject_BB(val)); }
	public void Add(long val) { Add(new JSONObject_BB(val)); }
	public void Add(int val) { Add(new JSONObject_BB(val)); }
	public void Add(string str) { Add(StringObject(str)); }
	public void Add(AddJSONConents content) { Add(new JSONObject_BB(content)); }
	public void Add(JSONObject_BB obj) {
		if(obj) {		//Don't do anything if the object is null
			if(type != JSONObject_BB.Type.ARRAY) {
				type = JSONObject_BB.Type.ARRAY;		//Congratulations, son, you're an ARRAY now
				if(list == null)
					list = new List<JSONObject_BB>();
			}
			list.Add(obj);
		}
	}
	public void AddField(string name, bool val) { AddField(name, new JSONObject_BB(val)); }
	public void AddField(string name, long val) { AddField(name, new JSONObject_BB(val)); }
	public void AddField(string name, int val) { AddField(name, new JSONObject_BB(val)); }
	public void AddField(string name, AddJSONConents content) { AddField(name, new JSONObject_BB(content)); }
	public void AddField(string name, string val) {	AddField(name, StringObject(val)); }
	public void AddField(string name, JSONObject_BB obj) {
		if(obj) {		//Don't do anything if the object is null
			if(type != JSONObject_BB.Type.OBJECT) {
				keys = new List<string>();
				if(type == Type.ARRAY) {
					for(int i = 0; i < list.Count; i++)
						keys.Add(i + "");
				} else if(list == null)
					list = new List<JSONObject_BB>();
				type = JSONObject_BB.Type.OBJECT;		//Congratulations, son, you're an OBJECT now
			}
			keys.Add(name);
			list.Add(obj);
		}
	}
	public void SetField(string name, bool val) { SetField(name, new JSONObject_BB(val)); }
	public void SetField(string name, long val) { SetField(name, new JSONObject_BB(val)); }
	public void SetField(string name, int val) { SetField(name, new JSONObject_BB(val)); }
	public void SetField(string name, JSONObject_BB obj) {
		if(HasField(name)) {
			list.Remove(this[name]);
			keys.Remove(name);
		}
		AddField(name, obj);
	}
	public void RemoveField(string name) {
		if(keys.IndexOf(name) > -1) {
			list.RemoveAt(keys.IndexOf(name));
			keys.Remove(name);
		}
	}
	public delegate void FieldNotFound(string name);
	public delegate void GetFieldResponse(JSONObject_BB obj);
	public void GetField(ref bool field, string name, FieldNotFound fail = null) {
		if(type == JSONObject_BB.Type.OBJECT) {
			int index = keys.IndexOf(name);
			if(index >= 0) {
				field = list[index].b;
				return;
			}
		} 
		if(fail != null) fail.Invoke(name);
	}

	public void GetField(ref long field, string name, FieldNotFound fail = null) {
		if(type == JSONObject_BB.Type.OBJECT) {
			int index = keys.IndexOf(name);
			if(index >= 0){
				field = list[index].n;
				return;
			}
		}
		if(fail != null) fail.Invoke(name);
	}
	public void GetField(ref int field, string name, FieldNotFound fail = null) {
		if(type == JSONObject_BB.Type.OBJECT) {
			int index = keys.IndexOf(name);
			if(index >= 0) {
				field = (int)list[index].n;
				return;
			}
		}
		if(fail != null) fail.Invoke(name);
	}
	public void GetField(ref uint field, string name, FieldNotFound fail = null) {
		if(type == JSONObject_BB.Type.OBJECT) {
			int index = keys.IndexOf(name);
			if(index >= 0) {
				field = (uint)list[index].n;
				return;
			}
		}
		if(fail != null) fail.Invoke(name);
	}
	public void GetField(ref string field, string name, FieldNotFound fail = null) {
		if(type == JSONObject_BB.Type.OBJECT) {
			int index = keys.IndexOf(name);
			if(index >= 0) {
				field = list[index].str;
				return;
			}
		}
		if(fail != null) fail.Invoke(name);
	}
	public void GetField(string name, GetFieldResponse response, FieldNotFound fail = null) {
		if(response != null && type == Type.OBJECT) {
			int index = keys.IndexOf(name);
			if(index >= 0) {
				response.Invoke(list[index]);
				return;
			}
		}
		if(fail != null) fail.Invoke(name);
	}
	public JSONObject_BB GetField(string name) {
		if(type == JSONObject_BB.Type.OBJECT)
			for(int i = 0; i < keys.Count; i++)
				if((string)keys[i] == name)
					return (JSONObject_BB)list[i];
		return null;
	}
	public bool HasFields(string[] names) {
		foreach(string name in names)
			if(!keys.Contains(name))
				return false;
		return true;
	}
	public bool HasField(string name) {
		if(type == JSONObject_BB.Type.OBJECT)
			for(int i = 0; i < keys.Count; i++)
				if((string)keys[i] == name)
					return true;
		return false;
	}
	public void Clear() {
		type = JSONObject_BB.Type.NULL;
		if(list != null)
			list.Clear();
		if (keys != null)
			keys.Clear();
		str = "";
		n = 0;
		b = false;
	}
	public JSONObject_BB Copy() {
		return new JSONObject_BB(print());
	}
	/*
	 * The Merge function is experimental. Use at your own risk.
	 */
	public void Merge(JSONObject_BB obj) {
		MergeRecur(this, obj);
	}
	/// <summary>
	/// Merge object right into left recursively
	/// </summary>
	/// <param name="left">The left (base) object</param>
	/// <param name="right">The right (new) object</param>
	static void MergeRecur(JSONObject_BB left, JSONObject_BB right) {
		if(left.type == JSONObject_BB.Type.NULL)
			left.Absorb(right);
		else if(left.type == Type.OBJECT && right.type == Type.OBJECT) {
			for(int i = 0; i < right.list.Count; i++) {
				string key = (string)right.keys[i];
				if(right[i].isContainer) {
					if(left.HasField(key))
						MergeRecur(left[key], right[i]);
					else
						left.AddField(key, right[i]);
				} else {
					if(left.HasField(key))
						left.SetField(key, right[i]);
					else
						left.AddField(key, right[i]);
				}
			}
		} else if(left.type == Type.ARRAY && right.type == Type.ARRAY) {
			if(right.Count > left.Count) {
				Debug.LogError("Cannot merge arrays when right object has more elements");
				return;
			}
			for(int i = 0; i < right.list.Count; i++) {
				if(left[i].type == right[i].type) {			//Only overwrite with the same type
					if(left[i].isContainer)
						MergeRecur(left[i], right[i]);
					else {
						left[i] = right[i];
					}
				}
			}
		}
	}
	public string print(bool pretty = false) {
		return print(0, pretty);
	}
	#region STRINGIFY
	public string print(int depth, bool pretty = false) {	//Convert the JSONObject into a string
		if(depth++ > MAX_DEPTH) {
			Debug.Log("reached max depth!");
			return "";
		}
		string str = "";
		switch(type) {
			case Type.STRING:
				str = "\"" + this.str + "\"";
				break;
			case Type.NUMBER:
				str += n;
				break;
 
			case JSONObject_BB.Type.OBJECT:
				str = "{";
				if(list.Count > 0) {
#if(PRETTY)	//for a bit more readability, comment the define above to disable system-wide
					if(pretty)
						str += "\n";
#endif
					for(int i = 0; i < list.Count; i++) {
						string key = (string)keys[i];
						JSONObject_BB obj = (JSONObject_BB)list[i];
						if(obj) {
#if(PRETTY)
							if(pretty)
								for(int j = 0; j < depth; j++)
									str += "\t"; //for a bit more readability
#endif
							str += "\"" + key + "\":";
							str += obj.print(depth, pretty) + ",";
#if(PRETTY)
							if(pretty)
								str += "\n";
#endif
						}
					}
#if(PRETTY)
					if(pretty)
						str = str.Substring(0, str.Length - 1);		//BOP: This line shows up twice on purpose: once to remove the \n if readable is true and once to remove the comma
#endif
					str = str.Substring(0, str.Length - 1);
				}
#if(PRETTY)
				if(pretty && list.Count > 0) {
					str += "\n";
					for(int j = 0; j < depth - 1; j++)
						str += "\t"; //for a bit more readability
				}
#endif
				str += "}";
				break;
			case JSONObject_BB.Type.ARRAY:
				str = "[";
				if(list.Count > 0) {
#if(PRETTY)
					if(pretty)
						str += "\n"; //for a bit more readability
#endif
					foreach(JSONObject_BB obj in list) {
						if(obj) {
#if(PRETTY)
							if(pretty)
								for(int j = 0; j < depth; j++)
									str += "\t"; //for a bit more readability
#endif
							str += obj.print(depth, pretty) + ",";
#if(PRETTY)
							if(pretty)
								str += "\n"; //for a bit more readability
#endif
						}
					}
#if(PRETTY)
					if(pretty)
						str = str.Substring(0, str.Length - 1);	//BOP: This line shows up twice on purpose: once to remove the \n if readable is true and once to remove the comma
#endif
					str = str.Substring(0, str.Length - 1);
				}
#if(PRETTY)
				if(pretty && list.Count > 0) {
					str += "\n";
					for(int j = 0; j < depth - 1; j++)
						str += "\t"; //for a bit more readability
				}
#endif
				str += "]";
				break;
			case Type.BOOL:
				if(b)
					str = "true";
				else
					str = "false";
				break;
			case Type.NULL:
				str = "null";
				break;
		}
		return str;
	}
	#endregion
	public static implicit operator WWWForm(JSONObject_BB obj){
		WWWForm form = new WWWForm();
		for(int i = 0; i < obj.list.Count; i++){
			string key = i + "";
			if(obj.type == Type.OBJECT)
				key = obj.keys[i];
			string val = obj.list[i].ToString();
			if(obj.list[i].type == Type.STRING)
				val = val.Replace("\"", "");
			form.AddField(key, val);
		}
		return form;
	}
	public JSONObject_BB this[int index] {
		get {
			if(list.Count > index) return (JSONObject_BB)list[index];
			else return null;
		}
		set {
			if(list.Count > index)
				list[index] = value;
		}
	}
	public JSONObject_BB this[string index] {
		get {
			return GetField(index);
		}
		set {
			SetField(index, value);
		}
	}
	public override string ToString() {
		return print();
	}
	public string ToString(bool pretty) {
		return print(pretty);
	}
	public Dictionary<string, string> ToDictionary() {
		if(type == Type.OBJECT) {
			Dictionary<string, string> result = new Dictionary<string, string>();
			for(int i = 0; i < list.Count; i++) {
				JSONObject_BB val = (JSONObject_BB)list[i];
				switch(val.type) {
					case Type.STRING: result.Add((string)keys[i], val.str); break;
					case Type.NUMBER: result.Add((string)keys[i], val.n + ""); break;
					case Type.BOOL: result.Add((string)keys[i], val.b + ""); break;
					default: Debug.LogWarning("Omitting object: " + (string)keys[i] + " in dictionary conversion"); break;
				}
			}
			return result;
		} else Debug.LogWarning("Tried to turn non-Object JSONObject into a dictionary");
		return null;
	}
	public static implicit operator bool(JSONObject_BB o) {
		return (object)o != null;
	}
}