using System;
using System.Collections.Generic;

namespace BraceMatcher.Bus
{
    public class SimpleBrace
    {
        public string braceString;
        public char startBracket;
        public char endBracket;

        public int ValidateBraceString()
        {
            if (startBracket == '\0' || endBracket == '\0'){
                return -1;
            }
            return ValidateBrackets();
        }

        private int ValidateBrackets()
        {
            List<char> braces = new List<char>(); 
            List<int> startBracketIndices = new List<int>(); 
            List<int> endBracketIndices = new List<int>();
            int toBeRemovedStartBracketIndex, matchedEndBracketIndex;

            braces.AddRange(braceString);

            for (int at = 0; at < braceString.Length; at++)
            {
                if(braces[at] == startBracket){
                    startBracketIndices.Add(at);
                }else if(braces[at] == endBracket){
                    endBracketIndices.Add(at);
                }
            }

            if (startBracketIndices[0] > endBracketIndices[0]){
                return endBracketIndices[0];
            }else{
                while (startBracketIndices.Count > 0 && endBracketIndices.Count > 0){
                    toBeRemovedStartBracketIndex = startBracketIndices[startBracketIndices.Count - 1];
                    startBracketIndices.Remove(toBeRemovedStartBracketIndex);
                    matchedEndBracketIndex = endBracketIndices.FindAll(n => n > toBeRemovedStartBracketIndex)[0];
                    endBracketIndices.Remove(matchedEndBracketIndex);
                }

                if (startBracketIndices.Count > 0){
                    return startBracketIndices[0];
                }else if (endBracketIndices.Count > 0){
                    return endBracketIndices[0];
                }
            }

            return -1;
        }
    }
}
