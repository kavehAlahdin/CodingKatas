using System;
using System.IO;
using System.Collections.Generic;
public class Anagram{
    string sourceWord;
    private Dictionary<char,int> sourceWordAnalysis;
    Dictionary<string, Dictionary<char,int> > wordListDictionary=new Dictionary<string, Dictionary<char, int>>();
    
    public Anagram(String sourceWord, string dictionaryFileName){
        //builds a dictionary of the words as key, and for each one list of its characters and the number of their repition as value.
        if(File.Exists(dictionaryFileName))
        using(StreamReader wordListStream=File.OpenText(dictionaryFileName)){
            while (wordListStream.Peek() >=0){
                String currentWord=wordListStream.ReadLine();
                Dictionary<char,int> wordAnalysis =createUniqueCharacterRepetitionDic(currentWord);
                wordListDictionary.Add(currentWord,wordAnalysis);
            }
        }
        this.sourceWord=sourceWord;
        this.sourceWordAnalysis=createUniqueCharacterRepetitionDic(this.sourceWord);
    }
    //This methods is where the multiple Anagram are created.As an example If 2-word Anagram is desired, this method would be used  with AnagramWordNumber=2
    private List<List<String>> createMultiAnagram(int AnagramWordNumber){
        List <List<string>> result= new List<List<string>>();
        
        for(int i=0;i<AnagramWordNumber;i++){
           List<String> anagramWordDictionary=findAnagram();
           Dictionary<char,int>  differenceWordAnalysis=createDifferenceWordDictionary(anagramWordDictionary);
            
        }
        return result;
    }
    private bool isAnagram(String targetWord){
        Dictionary<char,int> targetwordAnalysis=wordListDictionary[targetWord];
        foreach(KeyValuePair<char,int> LetterCount in targetwordAnalysis){
            if(!sourceWordAnalysis.ContainsKey(LetterCount.Key)) 
                return false;
            if(LetterCount.Value>this.sourceWordAnalysis[LetterCount.Key]) 
                return false;
        }
        return true;
    }
    private Dictionary<char,int> createDifferenceWordDictionary(string subtractingWord){
        Dictionary<char,int> differenceDic=new Dictionary<char, int>();
        foreach(KeyValuePair<char,int> letterPair in sourceWordAnalysis)
            differenceDic[letterPair.Key]=sourceWordAnalysis[letterPair.Key]-letterPair.Value;
        return differenceDic;
    }
    private Dictionary<char,int>  createUniqueCharacterRepetitionDic(string word){
        Dictionary<char, int>  LetterDictionary=new Dictionary<char, int> ();
        foreach(char letter in word.ToLower())
            if(!LetterDictionary.ContainsKey(letter))
                LetterDictionary.Add(letter,1);
            else
                LetterDictionary[letter]++;
        return LetterDictionary;
    }

    private Dictionary<string , string> resultTwoWordAnagram;
    static  int counter=0;
    public List<String> findAnagram(){
        List<String> resultAnagramDictionary=new List<string>();
        foreach(KeyValuePair<String, Dictionary<char,int>> currentWordPair in wordListDictionary){
            if(isAnagram(currentWordPair.Key))
                resultAnagramDictionary.Add(currentWordPair.Key);
        }
        return resultAnagramDictionary;
    }

 
}