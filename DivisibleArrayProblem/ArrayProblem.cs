using System;
using System.Collections.Generic;



class DivisibleArray
{
   
    public static int[] FindTheMostDivisbleArray(List<int[]> arrayList, int number)
    {
        Dictionary<int,  List<int[]>> arraydictionary = new Dictionary<int,  List<int[]>>();
  
        if (arrayList.Count > 0 && number > 0)
        {
            foreach (int [] array in arrayList)
            {
                int divisiblityCount = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % number == 0)
                    {
                        divisiblityCount++;

                    }

                }

                if (divisiblityCount > 0)
                {
                    if (!arraydictionary.ContainsKey(divisiblityCount))
                    {
                        arraydictionary.Add(divisiblityCount, new List<int[]>() { array});
                    }
                    else
                    {
                        arraydictionary[divisiblityCount].Add(array);                     
                                            

                    }
                }
            }


        }
        if (arraydictionary.Count > 0)
        {
            foreach (var item in arraydictionary)
            {
                
                if (item.Value.Count > 1)
                {
                    //Handle arrays with same number of items divisible by number
                    //create new array 
                    int newArrLenght = item.Key * 2;
                    int[] newArr = new int[newArrLenght];
                    int k = 0, a;
                    for (a = 0; a < item.Value.Count; a++)
                    {

                        for (int j = 0; j < item.Value[a].Length; j++)
                        {
                            if ((item.Value[a][j]) % number == 0)
                            {
                                newArr[k] = item.Value[a][j];
                                k++;
                                if (k == item.Key)
                                    break;

                            }

                        }

                    }
                    return newArr;
                }
                
                    
              }
        }   
            //find array which has max number of item divisible by number
            int maxcount = 0;
            foreach (var arrayItem in arraydictionary)
            {
                if (maxcount < arrayItem.Key)
                {
                    maxcount = arrayItem.Key;
                }


            }            
            
        var result = arraydictionary[maxcount][0];
        return result;

    }


}

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Hello, world!");

        List<int[]> arraycollection = new List<int[]>();

        //max divisble senario
        arraycollection.Add(new int[] { 1, 2, 3, 4, 5 });
        arraycollection.Add(new int[] { 1, 3, 4, 6, 9 });
        arraycollection.Add(new int[] { 10, 12, 9, 7, 8 });
        arraycollection.Add(new int[] { 12, 6, 9, 18, 14 });
        var resultarray = DivisibleArray.FindTheMostDivisbleArray(arraycollection, 3);
        for (int i = 0; i < resultarray.Length; i++)
        {
            Console.Write(resultarray[i] + ",");
        }

        arraycollection.Clear();
        Console.Write('\n');
        //same divisible senario
        arraycollection.Add(new int[] { 1, 2, 3, 4, 5 });
        arraycollection.Add(new int[] { 1, 3, 4, 6, 9 });
        arraycollection.Add(new int[] { 3, 9, 10, 11, 18 });
        arraycollection.Add(new int[] { 10, 12, 9, 7, 8 });
        arraycollection.Add(new int[] { 12, 7, 9, 8, 14 });

        resultarray = DivisibleArray.FindTheMostDivisbleArray(arraycollection, 3);
        for (int i = 0; i < resultarray.Length; i++)
        {
            Console.Write(resultarray[i] + ",");
        }








    }
}