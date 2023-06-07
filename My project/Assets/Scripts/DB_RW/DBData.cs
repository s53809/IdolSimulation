using System;
using System.Collections.Generic;

public class DBData {
    public Dictionary<string, int> intData;
    public Dictionary<string, float> floatData;
    public Dictionary<string, string> stringData;

    public DBData() {
        intData = new Dictionary<string, int>();
        floatData = new Dictionary<string, float>();
        stringData = new Dictionary<string, string>();
    }
}