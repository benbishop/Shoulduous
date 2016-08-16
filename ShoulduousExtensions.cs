using System;
using System.Collections.Generic;
using System.Linq;


namespace Shoulduous
{
    
    
    public static class ShoulduousExtensions
    {
        //bool assertions
        public static void ShouldBeTrue(this bool source)
        {
            Test(()=> {return source == true;}, "Should be true");
        }
        
        public static void ShouldBeFalse(this bool source)
        {
            Test(()=>{return source == false;}, "Should be false");
        }
        
        //int assertions
        public static void ShouldBeGreaterThan(this int source, int anInt)
        {
            Test(()=> {return source > anInt;}, string.Format("{0} should be greater than {1}", source,anInt));            
        }
        
        public static void ShouldBeGreaterThanOrEqual(this int source, int anInt)
        {
            Test(()=> {return source >= anInt;}, string.Format("{0} should be greater than or equal {1}", source,anInt));            
        }        

        public static void ShouldBeLessThan(this int source, int anInt)
        {
            Test(()=> {return source < anInt;}, string.Format("{0} should be less than {1}", source,anInt));            
        }
        
        public static void ShouldBeLessThanOrEqual(this int source, int anInt)
        {
            Test(()=> {return source <= anInt;}, string.Format("{0} should be less than or equal {1}", source,anInt));            
        }        
      
        public static void ShouldEqual(this int source, int anInt)
        {
            Test(()=> {return source == anInt;}, string.Format("{0} should equal {1}", source,anInt));            
        }
        
        //helper methods
        
        private static void Test(Func<Boolean> assertion, string failMessage)
        {
            if(!assertion())
                ThrowException(failMessage);
        }
            
        
        private static void ThrowException(string message)
        {
            throw(new Exception(message));            
        
        }
    }
}
