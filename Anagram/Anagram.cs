using System;
using System.IO;
using System.Collections.Generic;
public class Anagram{
    private static bool isSubSetOfSourceWord(string word,string sourceWord){
        int index=0;
        if(word.Length==0)return true;
        foreach(char character in word)
        {
            if(!sourceWord.Contains(character.ToString()))
                return false;
            else{

            string newSourceWord=sourceWord.Remove(index,1);
            string newWord=word.Remove(index,1);
            index++;
            return isSubSetOfSourceWord(newWord,newSourceWord);
            }
        }
        return true;
    }
    public static Dictionary<char,int>  countLetters(string word){
        Dictionary<char, int>  LetterCountDictionary=new Dictionary<char, int> ();
        foreach(char letter in word)
            {
            if(!LetterCountDictionary.ContainsKey(char.ToLower(letter)))
                LetterCountDictionary.Add(letter,1);
            else
                LetterCountDictionary[letter]++;
            }
        return LetterCountDictionary;
    }
    public bool isSubAnagram(string wordTobeCheck,string sourceWord){
        if(wordTobeCheck==null ||wordTobeCheck.Length==0) return true;
        if(wordTobeCheck.Length>sourceWord.Length)return false;
        bool result=true;
        return true;
    }
    private string findAnagram(string sourceWord,List<string> wordList){
        string anagram=string.Empty;
        

        return "hi";
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
        //Console.WriteLine("{0}-{1}",CandidateNumber,CurrentWord);
    }
    Dictionary<char,int> sourceWordCharacters=countLetters(sourceWord);
    foreach(KeyValuePair<char,int> LetterCountPair in sourceWordCharacters)
        
        //Console.Write("("+LetterCountPair.Key+","+LetterCountPair.Value+")");

    wordList.Close();


    }
}