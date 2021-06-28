using System;
using System.Collections.Generic;



class DivisibleArray
{
   
    public static int[] FindTheMostDivisbleArray(List<int[]> arrayList, int number)
    {
        Dictionary<int,  List<int[]>> arraydictionary = new Dictionary<int,  List<int[]>>();
  
        if (arrayList.Count > 0 && number > 0)
        {
            //prepare dictionary of divisibilty count and array(s)
            foreach (int [] array in arrayList)
            {
                int divisiblityCount = 0;
                try
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % number == 0)
                        {
                            divisiblityCount++;

                        }

                    }
                }
                catch (IndexOutOfRangeException io)
                {
                    throw new IndexOutOfRangeException("Error occured in process " + io.Message);
                }

                if (divisiblityCount > 0)
                {
                    //add key divisibilty count and array to the dictionary
                    if (!arraydictionary.ContainsKey(divisiblityCount))
                    {
                        arraydictionary.Add(divisiblityCount, new List<int[]>() { array});
                    }
                    else
                    {
                        //divisibility count already exists so attach the array 
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
                    
                    int newArrLenght = item.Key * item.Value.Count;
                    int[] newArr = new int[newArrLenght];
                    int k = 0, a;
                    try
                    {
                        //Handle arrays with same number of items divisible by number
                        //create new array 
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
                    }
                    catch (IndexOutOfRangeException io)
                    {
                        throw new IndexOutOfRangeException("Error occured in processing " + io.Message);

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
        try
        {
            var resultarray1 = DivisibleArray.FindTheMostDivisbleArray(arraycollection, 3);
            Console.WriteLine("Processing successful!!");
            for (int i = 0; i < resultarray1.Length; i++)
            {
                Console.Write(resultarray1[i] + ",");

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Processing failed!! " + ex.Message);
        }


        arraycollection.Clear();
        Console.Write('\n');
        //same divisible senario
        arraycollection.Add(new int[] { 1, 2, 3, 4, 5 });
        arraycollection.Add(new int[] { 1, 3, 4, 6, 9 });
        arraycollection.Add(new int[] { 3, 9, 10, 11, 18 });
        arraycollection.Add(new int[] { 10, 12, 9, 7, 8 });
        arraycollection.Add(new int[] { 12, 7, 9, 8, 14 });
        arraycollection.Add(new int[] { 30,27, 15, 8, 14 });

        try
        {

         var   resultarray2 = DivisibleArray.FindTheMostDivisbleArray(arraycollection, 3);
            Console.WriteLine("Proccessing successful!!");
            for (int i = 0; i < resultarray2.Length; i++)
            {
                Console.Write(resultarray2[i] + ",");
            }

        }
        catch(Exception ex)
        {
            Console.WriteLine("Proccessing failed "+ex.Message);
        }
      
    }
}
