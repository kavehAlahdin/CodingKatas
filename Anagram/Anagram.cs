using System;
using System.IO;
using System.Collections.Generic;
public class Anagram{
    private static bool isSubSetOfSourceWord(string word,string sourceWord){
          int index=0;
          foreach(char character in word)
            {
                if(word.Length==0)return true;
                if(!sourceWord.Contains(character.ToString()))
                    return false;
                string newSourceWord=sourceWord.Remove(index,1);
                string newWord=word.Remove(index,1);
                index++;
                return isSubSetOfSourceWord(newWord,newSourceWord);
                
            }
        return true;
    }
    private const string wordListFileName="wordlist.txt";
    public static void Main(){
    string sourceWord = "documenting";
    StreamReader wordList=File.OpenText(wordListFileName);
    int CandidateNumber=0;
    string CurrentWord=string.Empty;
    List<string> wordCandidateList=new List<string>();
    string word1=string.Empty;
    string word2=string.Empty;
    while((CurrentWord= wordList.ReadLine())!=null){
        if(CurrentWord.Length>=sourceWord.Length)continue;
        if(!isSubSetOfSourceWord(CurrentWord,sourceWord))continue;        
        wordCandidateList.Add(CurrentWord);
        CandidateNumber++;
        Console.WriteLine("{0}-{1}",CandidateNumber,CurrentWord);
    }


    }
}