using System;
using System.IO;
using System.Collections.Generic;
public class Anagram{
    public Dictionary<char,int> sourceWordAnalysis;
    Dictionary<string, Dictionary<char,int> > wordListDictionary=new Dictionary<string, Dictionary<char, int>>();
    private Dictionary<string , string> resulMultiAnagram;
    private String sourceWord;
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
        this.sourceWordAnalysis=createUniqueCharacterRepetitionDic(sourceWord);
        this.sourceWord=sourceWord;
    }
    //This methods is where the multiple Anagram are created.As an example If 2-word Anagram is desired, this method would be used  with AnagramWordNumber=2
    public static String createStrFromDic(Dictionary<char,int> wordAnalysis){
        String resultWord=string.Empty;
        foreach(KeyValuePair<char,int> pair in wordAnalysis)
            for (int i = 0; i < pair.Value ; i++)
                resultWord+=pair.Key;
        return resultWord;
    }
    private List<List<String>> createMultiAnagram(int AnagramWordNumber){
        List <List<string>> result= new List<List<string>>();
        
        for(int i=0;i<AnagramWordNumber;i++){
           List<String> anagramWordList=findAnagram(this.sourceWord);
           foreach (String currentAnagram in anagramWordList)
           {
               if((anagramWordList==null)&&(anagramWordList.C)
                string  remainingWord=Anagram.createStrFromDic(createDifferenceWordDictionary(currentAnagram));


           }
            
        }
        return result;
    }
    private bool isAnagram(String firstWord,String targetWord){
        Dictionary<char,int> targetwordAnalysis=wordListDictionary[targetWord];
        Dictionary<char,int> firstWordAnalysis=createUniqueCharacterRepetitionDic(firstWord);
        foreach(KeyValuePair<char,int> LetterCount in targetwordAnalysis){
            if(!firstWordAnalysis.ContainsKey(LetterCount.Key)) 
                return false;
            if(LetterCount.Value>this.firstWordAnalysis[LetterCount.Key]) 
                return false;
        }
        return true;
    }
    private Dictionary<char,int> createDifferenceWordDictionary(string subtractingWord){
        Dictionary<char,int> differenceDic=new Dictionary<char, int>();
        foreach(KeyValuePair<char,int> letterPair in sourceWordAnalysis)
            if(sourceWordAnalysis[letterPair.Key]>letterPair.Value)
                differenceDic[letterPair.Key]=sourceWordAnalysis[letterPair.Key]-letterPair.Value;
            else
                differenceDic.Remove(letterPair.Key);
        return differenceDic;
    }
    private static Dictionary<char,int>  createUniqueCharacterRepetitionDic(string word){
        Dictionary<char, int>  LetterDictionary=new Dictionary<char, int> ();
        foreach(char letter in word.ToLower())
            if(!LetterDictionary.ContainsKey(letter))
                LetterDictionary.Add(letter,1);
            else
                LetterDictionary[letter]++;
        return LetterDictionary;
    }
    static  int counter=0;
    public List<String> findAnagram(String firstWord){
        List<String> resultAnagramDictionary=new List<string>();
        foreach(KeyValuePair<String, Dictionary<char,int>> currentWordPair in wordListDictionary){
            if(isAnagram(firstWord,currentWordPair.Key))
                resultAnagramDictionary.Add(currentWordPair.Key);
        }
        return resultAnagramDictionary;
    }

 
}