using System;
using System.Collections.Generic;
using System.Linq;


namespace Shoulduous
{
    public class TestSuite
    {
     
         protected List<Tuple<Action, string>> Tests = new List<Tuple<Action, string>>();
         
         protected virtual void SetupSuite()
         {
             
         }
         
         protected virtual void SetupTest()
         {
             
         }
         
         protected virtual void TearDownTest()
         {
             
         }
         
         protected virtual void TearDownSuite()
         {
             
         }

     
         protected void Register(Action test, string testName = "")
         {

             Tests.Add(new Tuple<Action, string>(test, testName));
         }   
         
         public void RunAll()
         {
             var successCount = Tests.Count;
             
             SetupSuite();
             
             foreach(var testNamePair in Tests)
             {
                 SetupTest();
                 try{
                     testNamePair.Item1();
                     if(string.IsNullOrEmpty(testNamePair.Item2))
                         Console.Out.WriteLine("Test passed...");
                     else
                         Console.Out.WriteLine(string.Format("{0} passed...", testNamePair.Item2));    
                         
                 
                 }catch(Exception ex)
                 {
                     successCount = successCount - 1;
                     if(string.IsNullOrEmpty(testNamePair.Item2))
                         Console.Error.WriteLine("Test FAILED...");
                     else
                         Console.Error.WriteLine(string.Format("{0} FAILED", testNamePair.Item2));
                 }
                TearDownTest();


             }
             if(successCount == Tests.Count)
                 Console.Out.WriteLine(string.Format("{0} Tests Passed!", successCount));
             else
                 Console.Error.WriteLine(string.Format("{0} Tests FAILED...", Tests.Count -successCount));
                 
             TearDownSuite();    
                 
                 
                 //    Console.Error.WriteLine(string.Format("{0} Tests FAILED", failCount));
         }
    }
}
