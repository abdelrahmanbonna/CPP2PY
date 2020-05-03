using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpp2Py
{
    class PyConverter
    {
        public string a; //input code
        public string output = ""; //output code
        public string errorrs = ""; //errors string
        
        List<string> cKeyWords = new List<string> {"int","string","bool","float","double","char"
            ,"while","if","else","for","cout","cin","\n"}; //c words to check

        List<string> pyKeyWords = new List<string> {" "," "," "," "," "," "
            ,"while","if","else","for","print","input" }; //Python words to check

        char[] alphabet = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q',
                                    'r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J',
                                    'K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','+','-','/','*',
                                    '1','2','3','4','5','6','7','8','9','0',' ','\'','\\','\"','(',')','{','}','<',
                                    '>','=',';',',','\n','\r','\t','.' }; //all alphabet


        public bool LexicalError()
        {
            string error = "Lexical Error:  "; //error message base
            int x = 0; //no of errors
            string v = a;
            char[] ch = v.ToCharArray(); //converting string to array of char to deal with chars 
            foreach (char c in ch)
            {
                if (!alphabet.Contains(c)) //if the alpha is not in the array throw an error
                {
                    error = error + c;
                    x++;
                }
            }
            if (x > 0)
            {
                errorrs = error;
                v = "";
                return false;
            }
            else { v = ""; return true; }
        }

        public bool SyntaxError()
        {
            string error = "Syntax Error: "; //error message base
            int x = 0;
            char[] delims = new[] { '\n' };
            string[] strings = a.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in strings)
            {
                string ss = s;
                ss = ss.Replace("\n", String.Empty);
                ss = ss.Replace("\r", String.Empty);
                ss = ss.Replace("\t", String.Empty);
                char[] delims2 = new[] { ' ', '>', '<', '+', '-', '/', '*', '\n' };
                string[] strings2 = ss.Split(delims2, StringSplitOptions.RemoveEmptyEntries);

                if ((!ss.EndsWith(";\n") && !ss.EndsWith(";")) || !cKeyWords.Contains(strings2[0]))
                {
                    error = error + "Error in " + ss + "\n";
                    x++;
                }
                else
                {

                    if (cKeyWords[0] == strings2[0] || cKeyWords[3] == strings2[0] || cKeyWords[4] == strings2[0])
                    {
                        if (ss.Contains("="))
                        {
                            string newS = ss.Substring(ss.IndexOf("=") + 1).Replace(" ", String.Empty)
                                    .Replace(";", String.Empty);
                            try
                            {
                                var Value = int.Parse(newS);
                                strings2[0] = pyKeyWords[0];
                                foreach (string str in strings2)
                                {

                                    if (str != ";") { output = output + str + " "; }
                                }
                                output = output + "@";
                                output = output.Replace("@", System.Environment.NewLine);
                            }
#pragma warning disable CS0168 // Variable is declared but never used
                            catch (Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
                            {
                                try
                                {
                                    if (cKeyWords[3] == strings2[0] || cKeyWords[4] == strings2[0])
                                    {
                                        var Value = float.Parse(newS);
                                        if (cKeyWords[3] == strings2[0])
                                            strings2[0] = pyKeyWords[3];
                                        else if (cKeyWords[4] == strings2[0])
                                        {
                                            strings2[0] = pyKeyWords[4];
                                        }
                                        foreach (string str in strings2)
                                        {
                                            if (str != ";") { output = output + str + " "; }
                                        }
                                        output = output + "@";
                                        output = output.Replace("@", System.Environment.NewLine);
                                    }
                                    else
                                    {
                                        error = "Type error in the line " + s;
                                        x++;
                                    }
                                }
#pragma warning disable CS0168 // Variable is declared but never used
                                catch (Exception ee)
#pragma warning restore CS0168 // Variable is declared but never used
                                {
                                    error = "Type error in the line " + s;
                                    x++;
                                }
                            }
                        }
                    }
                    else if (cKeyWords[1] == strings2[0])
                    {
                        if (ss.Contains("="))
                        {
                            string newS = ss.Substring(ss.IndexOf("=") + 1).Replace(" ", String.Empty)
                                    .Replace(";", String.Empty);
                            if (newS.StartsWith("\"") && newS.EndsWith("\""))
                            {
                                strings2[0] = pyKeyWords[1];
                                foreach (string str in strings2)
                                {
                                    if (str != ";") { output = output + str + " "; }
                                }
                                output = output + "@";
                                output = output.Replace("@", System.Environment.NewLine);
                            }
                            else
                            {
                                error = "Type error in the line " + s;
                                x++;
                            }
                        }
                    }
                    else if (cKeyWords[5] == strings2[0])
                    {
                        if (ss.Contains("="))
                        {
                            string newS = ss.Substring(ss.IndexOf("=") + 1).Replace(" ", String.Empty)
                                    .Replace(";", String.Empty);
                            if (newS.StartsWith("\'") && newS.EndsWith("\'"))
                            {
                                strings2[0] = pyKeyWords[5];
                                foreach (string str in strings2)
                                {
                                    if (str != ";") { output = output + str + " "; }
                                }
                                output = output + "@";
                                output = output.Replace("@", System.Environment.NewLine);
                            }
                            else
                            {
                                error = "Type error in the line " + s;
                                x++;
                            }
                        }
                    }
                    else if (cKeyWords[2] == strings2[0])
                    {
                        if (ss.Contains("="))
                        {
                            string newS = ss.Substring(ss.IndexOf("=") + 1).Replace(" ", String.Empty)
                                    .Replace(";", String.Empty);
                            if (newS == "true" || newS == "false")
                            {
                                strings2[0] = pyKeyWords[2];
                                foreach (string str in strings2)
                                {
                                    if (str != ";") { output = output + str + " "; }
                                }
                                output = output + "@";
                                output = output.Replace("@", System.Environment.NewLine);
                            }
                            else
                            {
                                error = "Type error in the line " + s;
                                x++;
                            }
                        }
                    }
                }
            }
            if (x > 0)
            {
                errorrs = error;
              
                return false;
            }
            else
            {
                // here we remove all the ; from our codes
                string ssa="";
                foreach (char s in output) {
                    
                    if (s != ';') {
                        ssa = ssa + s;
                    }
                }
                output = ssa;
                return true;
            }
        }


    }
}
