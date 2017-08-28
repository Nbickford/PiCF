using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Diagnostics;
using System.Runtime.CompilerServices;

using Emil.GMP;

namespace PiCF
{
    public class globalvars
    {
        
        public static BigInt a = 1;
        public static BigInt b = 0;
        public static BigInt c = 0;
        public static BigInt d = 1;
        public static BigInt ea=1;//I can't pass more than one variable back.
        public static BigInt eb=0;//Yay for broken encapsulation!
        public static BigInt ec=0;
        public static BigInt ed=1;
        public static BigInt counter = 1;
        public static Int64 progressmod = 100000;
        public static string filename = "750pi.txt";
        public static string output = "output.txt";
        //public static string outtext = "";
        public static BigInt bigdigits;
        public static BigInt denom;
        public static BigInt power=100000;
        public static BigInt howgood=100;
        public static BigInt caution = 10000;
        public static BigInt numdigits = 0;
        public static Int32 ConstBlocks=100000;

        public static BigInt multiplyfactor = BigInt.Power(10, globalvars.ConstBlocks);
        public static Int32 maxBlocks = 0;
        public static BigInt prec = 300000;
        //Array variables
        public static Int64[] outarray ;
        public static Int64 outpos=0;//Might be the same as numdigits
        public static BigInt maxnum=0;
        //Verifying variables
        public static BigInt nnum=1;
        public static BigInt ndenom=0;
        public static BigInt biglhs;
        public static BigInt bigrhs;
        public static Int32 blocksread;
    }


    public class Program
    {
        static void Main(string[] args)
        {
            //Why int64s? Just so that this program might last 50 years. Of course, then the few people who remember computers in the 2010s will be me and 2 other people.
            Console.WriteLine("\t\tContinued Fraction Converter\n\t\t©2010 Neil Bickford");
            bool open = true;
            string temp;
            
            


            while (open)
            {
                Console.WriteLine("Enter in your choice:\n1-Change settings\n2-Read terms\n3-Compute!\n4-Help\n5-Credits\n6-Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\t\tSettings\n");
                        Console.WriteLine("Enter your choice:\n");
                        Console.Write("1-Filename: "); Console.Write(globalvars.filename);
                        Console.Write("\n2-Power: "); Console.Write(globalvars.power);
                        Console.Write("\n3-Precision: "); Console.Write(globalvars.prec);
                        Console.Write("\n4-Output: "); Console.Write(globalvars.output);
                        Console.Write("\n5-Increments to display: "); Console.Write(globalvars.progressmod);
                        Console.Write("\n6-Caution: ");Console.Write(globalvars.caution);
                        Console.Write("\n7-Read Blocks: ");Console.Write(globalvars.ConstBlocks);
                        Console.Write("\n");
                        string setchoice = Console.ReadLine();
                        switch (setchoice)
                        {
                            case "1":
                                Console.WriteLine("Enter in filename: ["+globalvars.filename+"]");
                                temp = Console.ReadLine();
                                Console.WriteLine();
                                if (temp != "")
                                {
                                    globalvars.filename = temp; ;
                                    
                                }
                                break;
                            case "2":
                                Console.WriteLine("Enter in power: ["+globalvars.power+"]");
                                
                                temp = Console.ReadLine();
                                Console.WriteLine();
                                if (temp != "")
                                {
                                    globalvars.power = new BigInt(temp) ;
                                    globalvars.prec = globalvars.power * 3;
                                }
                                globalvars.maxBlocks=(Int32)(globalvars.power / globalvars.ConstBlocks);

                                Console.WriteLine();
                                break;
                            case "3":
                                Console.WriteLine("Enter in precision: ["+globalvars.prec+"]");
                                temp = Console.ReadLine();
                                 Console.WriteLine();
                                 if (temp != "")
                                 {
                                     globalvars.prec = new BigInt(temp);
                                 }
                               
                                break;
                            case "4":
                                Console.WriteLine("Enter in output file: ["+globalvars.output+"]");
                                temp = Console.ReadLine();
                                Console.WriteLine();
                                if (temp != "")
                                {
                                    globalvars.output = temp; 
                                    
                                }
                                if (File.Exists(globalvars.output))
                                {
                                    Console.WriteLine("Overwrite existing file? (y/n)");
                                    if (Console.ReadLine() == "y")
                                    {
                                        File.Delete(globalvars.output);
                                    }
                                    else
                                    {

                                        String strDateTime;

                                        strDateTime = System.DateTime.Now.ToString();
                                        globalvars.filename = globalvars.filename.Replace(".txt", "-" + strDateTime.Replace(":", "-") + ".txt");
                                    }
                                }
                                break;
                            case "5":
                                Console.WriteLine("Enter in increment: ["+globalvars.progressmod+"]");
                                temp = Console.ReadLine();
                                Console.WriteLine();
                                if (temp != "")
                                {
                                    globalvars.progressmod = Int64.Parse(temp);
                                }
                                
                                break;
                            case "6":
                                Console.WriteLine("Enter in caution: ["+globalvars.caution+"]");
                                temp = Console.ReadLine();
                                Console.WriteLine();
                                if (temp != "")
                                {
                                    globalvars.caution = new BigInt(temp);
                                }
                                
                                break;
                            case "7":
                                Console.WriteLine("Enter in blocks to read: [" + globalvars.ConstBlocks + "]");
                                temp = Console.ReadLine();
                                Console.WriteLine();
                                if (temp != "")
                                {
                                    globalvars.ConstBlocks = Int32.Parse(temp);
                                    
                                    globalvars.multiplyfactor = BigInt.Power(10, globalvars.ConstBlocks);
                                }
                                globalvars.maxBlocks = (Int32)(globalvars.power / globalvars.ConstBlocks);
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("What range of terms would you like to read?");
                        Console.WriteLine("Oh wait, I haven't made this part yet.");
                        break;
                    case "3":
                        //Start computing
                        Console.WriteLine("Sure you want to start now with these settings (y/n)\n");
                        Console.Write("Digits: "); Console.Write(globalvars.filename);
                        Console.Write("\nPower: "); Console.Write(globalvars.power);
                        Console.Write("\nPrecision: "); Console.Write(globalvars.prec);
                        Console.Write("\nOutput: "); Console.Write(globalvars.output);
                        Console.Write("\nIncrements to display: "); Console.Write(globalvars.progressmod);
                        Console.Write("\nCaution: ");Console.Write(globalvars.caution);
                        Console.Write("\nRead Blocks: "); Console.Write(globalvars.ConstBlocks);
                        Console.Write("\n");
                        if (Console.ReadLine() == "y")
                        {
                            Console.Write("\nLoading digits...");
                            /*char[] digits = new char[(Int32)globalvars.power];
                            TextReader tr = new StreamReader(globalvars.filename);

                            tr.ReadBlock(digits, 0, (Int32)globalvars.power);
                            string tempdigits = new string(digits);

                            Console.Write("\n Parsing digits...");
                            globalvars.bigdigits = new BigInt(tempdigits.Remove(1, 1));
                             * */
                            /*if (globalvars.power <= globalvars.ConstBlocks)
                            {
                                char[] digits = new char[(Int32)globalvars.power];
                                TextReader tr = new StreamReader(globalvars.filename);

                                tr.ReadBlock(digits, 0, (Int32)globalvars.power);
                                string tempdigits = new string(digits);

                                Console.Write("\n Parsing digits...");
                                globalvars.bigdigits = new BigInt(tempdigits.Remove(1, 1));
                            }
                             
                            else
                             */
                            


                                char[] digits = new char[globalvars.ConstBlocks+1];
                                TextReader tr = new StreamReader(globalvars.filename);

                                tr.ReadBlock(digits, 0, (Int32)globalvars.ConstBlocks+1); //we remove the decimal point
                                //If the number of digits loaded is less than 2, bail!
                                if (digits.Length < 2)
                                {
                                    Console.WriteLine("Not enough digits in the file (There must be more than 2 digits)");
                                    break;
                                }
                                if (digits[1] != '.')
                                {
                                    Console.WriteLine("Decimal point must be right after the first digit in the file.");
                                    break;
                                }
                                string digitstring = new string(digits);
                                globalvars.bigdigits = new BigInt(digitstring.Remove(1, 1));
                            
                                //Start the loop to load and chug the digits from the file.
                                Int32 blocksRead = 1;
                                Boolean done = ((blocksRead >= globalvars.maxBlocks) || (digits.Length < globalvars.ConstBlocks));
                                BigInt tobeadded;
                                digits = new char[globalvars.ConstBlocks];
                                

                                while (!done)
                                {
                                    
                                    tr.ReadBlock(digits, 0, (Int32)globalvars.ConstBlocks);
                                    if ((blocksRead >= globalvars.maxBlocks) || (digits.Length < globalvars.ConstBlocks))
                                    {
                                        done = true;
                                        break;
                                    }


                                    globalvars.bigdigits = globalvars.bigdigits * globalvars.multiplyfactor;

                                    digitstring = new string(digits);
                                    tobeadded = new BigInt(digitstring);
                                    globalvars.bigdigits = globalvars.bigdigits + tobeadded;
                                    Console.WriteLine(blocksRead * globalvars.ConstBlocks);
                                    blocksRead++;


                                }
                                
                                
                                    
                            Console.WriteLine("Bit length of bigdigits: {0} . ", globalvars.bigdigits.BitLength);
                            Console.WriteLine("Blocks Read: ", blocksRead);
                            //BigInt has problems converting from Int to BigInt.
                            globalvars.blocksread = blocksRead;
                            globalvars.howgood = ((BigInt)(blocksRead.ToString()))*((BigInt)(globalvars.ConstBlocks).ToString())*20/21;
                            //Actually... This was for uberfudging. 
                            //globalvars.howgood = ((BigInt)(blocksRead.ToString())) * ((BigInt)(globalvars.ConstBlocks).ToString());
                            Console.WriteLine(globalvars.howgood);
                            Console.WriteLine("Creating initial digit array...");
                            globalvars.outarray= new Int64[(int)globalvars.howgood];
                                
                            
                                Console.Write("\n Started on ");
                                Console.Write(DateTime.Now);
                            
                                
                                compute(globalvars.bigdigits, BigInt.Power(10, blocksRead*globalvars.ConstBlocks - 1), globalvars.prec);
                                
                            //Write digits of string
                            
                            Console.WriteLine("Writing digits to file...");
                                TextWriter tw = new StreamWriter(globalvars.output,false,Encoding.ASCII);
                                for (int j=0;j<=globalvars.numdigits;j++)
                                {
                                    
                                    tw.WriteLine(globalvars.outarray[j]);

                                }
                                tw.Close();

                                Console.WriteLine("\nDone! Ending time:");
                                Console.WriteLine(DateTime.Now);
                                Console.WriteLine("Wrote "+ globalvars.numdigits+ " terms to the file.");
                                //Console.WriteLine("Actually " + globalvars.outarray.Length); 
                                Console.WriteLine("Maximum number encountered: {0}", globalvars.maxnum);
                                Console.WriteLine("BigInteger matrix: {0} , {1} , {2} , {3} .",globalvars.a,globalvars.b,globalvars.c,globalvars.d);
                            Console.WriteLine("Verifying digits...");
                            Console.WriteLine("Testing smoother...");
                            bool iscorrect=true;
                            for (int j = 0; j < globalvars.numdigits;j++ )
                            {
                                if (globalvars.outarray[j] < 1)
                                {
                                    iscorrect = false;
                                    break;
                                }
                            }
                            if(iscorrect){
                                Console.WriteLine("Smoother is correct; minimum term>0.");
                            }else{
                                Console.WriteLine("The minimum is {0} . Please use more caution.",globalvars.outarray.Min());
                            }
                            Console.WriteLine("You'll have to verify the additional digits on your own (to conserve memory).");
                            Console.WriteLine("Write bit lengths to verification.txt? (y/n)");
                            switch (Console.ReadLine())
                            {
                                case "y":
                                    Console.WriteLine("Writing bit verification...");
                                    tw = new StreamWriter("verification.txt");
                                    Console.WriteLine("0 out of 4");
                                    tw.WriteLine(globalvars.ea.BitLength);
                                    Console.WriteLine("1 out of 4");
                                    tw.WriteLine(globalvars.eb.BitLength);
                                    Console.WriteLine("2 out of 4");
                                    tw.WriteLine(globalvars.ec.BitLength);
                                    Console.WriteLine("3 out of 4");
                                    tw.WriteLine(globalvars.ed.BitLength);
                                    Console.WriteLine("4 out of 4-Done!");
                                    tw.Close();
                                    break;
                            }
                            open = false;
                            }
                        
                        
                        break;
                    case "4":
                        Console.WriteLine("\nWhat would you like help with?\n1-What do the settings mean?\n2-How long will this take?\n3-exit\n");
                        string helpchoice = Console.ReadLine();
                        switch (helpchoice)
                        {
                            case "1":
                                Console.WriteLine(" Guide to settings:\n\nDigts-the file from which to read the digits from.\nPower-the n in the <digits>/10^n\nPrecision-how many bits to be accurate to.\nOutput-the file to output the terms to.\nIncrements to display-the number of the steps it computes before showing its progress.\nCaution- how much to be smoothed. It normally should be about 2*sqrt(largest term expected), but this is unverified and 1056969105 usually does pretty well.\nReadBlocks- the size of the blocks to read in. ");
                                break;
                            case "2":
                                Console.WriteLine(" I don't know. You should probably do a few small tests before doing the large test to determine how long it will take.");
                                break;
                            
                        }

                        break;
                    case "5":
                        Console.WriteLine("\t\tCredits\npress enter to continue");
                        Console.ReadLine();
                        Console.WriteLine("\nProgramming: Neil Bickford");
                        Console.ReadLine();
                        Console.WriteLine("\nAlgorithm and Debugging: Bill Gosper");
                        Console.ReadLine();
                        Console.WriteLine("\nConcept of Pi: Archimedes");
                        Console.ReadLine();
                        Console.WriteLine("\nElectricity Payment: Peter Bickford");
                        Console.ReadLine();
                        Console.WriteLine("\n\nprogram c2010 neil bickford\n\n\n");
                        break;
                    case "6":
                        open = false;
                        break;
                    case "Euler likes pie":
                        int[] table = { 10, 100, 1000, 10000, 5, 25, 125, 3125, 6, 36, 216 };
                        foreach (Int32 i in table)
                        {
                            smooth(i,globalvars.caution);
                        }
                        Console.WriteLine(globalvars.outarray);
                        break;
                    case "John Napier":
                        Console.WriteLine(BitLength(BigInt.Power(2, 32) - 1));
                        break;
                    case "7":
                        Console.WriteLine("\nGo to neilbickford.com/pisecret.htm for this easter egg.");
                        break;
                    case "Frenicle de Bessie":
                        BigInt bign = new BigInt("1056969105");
                        //Int64 test = 24;
                        for (Int64 test = 1; test < 256; test++)
                        {
                            if (!bign.Multiply(test).Equals(test * 1056969105))
                            {
                                Console.WriteLine("{0}={1}?", bign.Multiply(test), test * 1056969105);
                            }
                        }
                        break;
                    case "Tests":
                        BigInt biga = BigInt.Power(2, 1000);
                        BigInt bigb = BigInt.Power(2, 998) +1;
                        Console.WriteLine(biga / bigb);
                        Console.WriteLine(BitLength(BigInt.Power(2,398657989) - 36));
                        Console.WriteLine(BigInt.Power(2, 20) - 1);
                        Console.WriteLine((BigInt.Power(2,20)-1)>>(10));
                        BigInt t1 = new BigInt("33445542");
                        BigInt t2 = new BigInt("314159");
                        Console.WriteLine(t1 + t2);
                        Console.WriteLine(t1 * t2);
                        Console.WriteLine(DateTime.Now);

                        Console.WriteLine("Allocating 4GB of memory...");
                        
                            
                            

                            List<Int32> testarray = new List<Int32>(500000000);
                            Console.WriteLine("Finished making array.");
                            for (Int32 index = 1; index < 500000000; index = index + 1)
                            {
                                testarray.Add(  (Int32)Math.Floor(Math.Sqrt(index)));
                                if (index % 50000000 == 0)
                                {
                                    Console.WriteLine(index);
                                }
                            }
                            Console.WriteLine("Finished Populating.");
                            Int64 t = 3;
                            Console.WriteLine((BigInt)(t.ToString()));
                            BigInt tsigh = new BigInt("54323");
                            t = (Int64)tsigh;
                            Console.WriteLine(t);
                            
                           
                        
                        
                        
                       
                         
                        
                        
                        
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        Console.WriteLine("Finished garbage collecting at {0} . ", DateTime.Now);
                        
                        
                        
                        Console.WriteLine(DateTime.Now);
                        
                        
                        break;
                         
                }


            }


        }
        static void compute(BigInt numerator, BigInt denominator, BigInt prec)
        {
            //Console.WriteLine(numerator.ToUIntArray().First());
            //Console.WriteLine(denominator.ToUIntArray().First());
            //Int32 maxnum = (Int32)(BitLength(Max(Abs(numerator), Abs(denominator)))-prec);
            Int32 maxnum = (Int32)Max(Min((BitLength(Max(Abs(denominator),Abs(numerator))) - prec),BitLength(denominator)-1),0);
                denominator = denominator.ShiftRight(maxnum);
                numerator = numerator.ShiftRight(maxnum);


            if (prec < 31)
            {

                Int64 ea = 1;
                Int64 eb = 0;
                Int64 ec = 0;
                Int64 ed = 1;
                Int64 t;
                Int64 ta;
                Int64 tc;
                Int64 tempdenominator;
                //Added:
                Int64 num = (Int64)numerator;
                Int64 denom = (Int64)denominator;
                Int64 innum = Math.Abs(num);

                //denominator = BigInteger.Divide(denominator, 100);
                 
                
                while ((denom != 0)&(innum<=Math.Abs(num*denom)))
                {

                    
                    t = Math.DivRem(num, denom, out tempdenominator);
                    //Matrix multiplication
                    ta = t*ea+eb;
                    eb = ea;
                    tc = t*ec+ed;
                    ed = ec;
                    ea = ta;
                    ec = tc;
                    
                    num = denom;
                    denom = tempdenominator;
                    smooth((BigInt)(t.ToString()),globalvars.caution);
                }
                //smooth(ea,eb,ec,ed);
                globalvars.ea = (BigInt)ea.ToString(); globalvars.eb = (BigInt)eb.ToString(); globalvars.ec = (BigInt)ec.ToString(); globalvars.ed = (BigInt)ed.ToString();
            }
            else
            {
                
                compute(numerator, denominator, prec/2);
                BigInt a = globalvars.ea; BigInt b = globalvars.eb; BigInt c = globalvars.ec; BigInt d = globalvars.ed;

                //Console.WriteLine();
                //Console.WriteLine(numerator * d - denominator * b);
                //Console.WriteLine(denominator * a - numerator * c);

                compute(numerator*d - denominator*b, denominator*a - numerator*c, (prec+1)/2);

                //Console.WriteLine();
                //Console.WriteLine(globalvars.ea);
                //Console.WriteLine(globalvars.eb);
                //Console.WriteLine(globalvars.ec);
                //Console.WriteLine(globalvars.ed);
                //Console.WriteLine(a);
                //Console.WriteLine(b);
               // Console.WriteLine(c);
               // Console.WriteLine(d);
                //BigInt ap = globalvars.ea; BigInt bp = globalvars.eb; BigInt cp = globalvars.ec; BigInt dp = globalvars.ed;
                BigInt ma = a * globalvars.ea + b * globalvars.ec;
                BigInt mb = globalvars.eb * a + b * globalvars.ed;
                BigInt mc = globalvars.ea * c + globalvars.ec * d;
                BigInt md = globalvars.eb * c + d * globalvars.ed;
                globalvars.ea = ma; globalvars.eb = mb; globalvars.ec = mc; globalvars.ed = md;

                //Console.WriteLine(globalvars.ea);
                //Console.WriteLine(globalvars.eb);
                //Console.WriteLine(globalvars.ec);
                //Console.WriteLine(globalvars.ed);

                return;
            }


        }
        static void fakesmooth(BigInt t, BigInt carefulness)
        {
            if (globalvars.outpos == 110466)
            {
                for (long i = globalvars.outpos-100; i < globalvars.outpos; i++)
                {
                    Console.WriteLine(globalvars.outarray[i]);
                }
                Console.WriteLine(t);
            }
            globalvars.counter = globalvars.counter + 1;
            globalvars.outarray[globalvars.outpos] = ((Int64)t);
            globalvars.outpos++;
            globalvars.numdigits = globalvars.numdigits + 1;
        }
        static void smooth(BigInt t,BigInt carefulness)
        {
            BigInt b = globalvars.a;
            BigInt a = globalvars.b+globalvars.a*t;
            
            BigInt d = globalvars.c;
            BigInt c = globalvars.d+globalvars.c*t;
            
            BigInt o;
            globalvars.a = a; globalvars.b = b; globalvars.c = c; globalvars.d = d;
          
            while ((globalvars.d != 0) & (globalvars.c != 0))
            {
                //Bill spotted a typing error in carefulness.
                if (!((carefulness*globalvars.a)/globalvars.c == (carefulness*globalvars.b)/globalvars.d))
                {
                    break;
                }
                globalvars.counter = globalvars.counter + 1;

                o = globalvars.a/globalvars.c;
               if (globalvars.counter <= globalvars.howgood)
                {
                    globalvars.outarray[globalvars.outpos]=( (Int64)o);
                    globalvars.outpos++;
                    globalvars.numdigits=globalvars.numdigits+1;
                    
                    if (o > globalvars.maxnum)
                    {
                        globalvars.maxnum = o;
                        Console.WriteLine("New maximum: " + (Int64)o + " at position " + (Int64)globalvars.numdigits);
                        
                    }
                    
                    if (globalvars.counter % globalvars.progressmod == 0)
                    {
                        Console.WriteLine(globalvars.counter);
                    }
                    if (o > 878783625)
                    {
                        Console.WriteLine("BEEP BEEP BEEP RECORD FOR PI BEATEN- Assuming this is pi that you're computing.");
                    }
                }
                
                a = globalvars.c;
                b = globalvars.d;
                c = globalvars.a-o*globalvars.c;
                d = globalvars.b-o*globalvars.d;
                globalvars.a = a; globalvars.b = b; globalvars.c = c; globalvars.d = d;
            }
              
        }
              
        
        
        static BigInt BitLength(BigInt x)
        {
   
            return x.BitLength;
        }
        static BigInt Abs(BigInt x)
        {
            if (x == 0)
            {
                return 0;
            }
            else if (x < 0)
            {
                return 0 - x;
            }
            else
            {
                return x;
            }
        }
        
        static BigInt Max(BigInt a, BigInt b)
        {
            if (a > b)
            {
                return a;
            }
            else if (a < b)
            {
                return b;
            }
            else
            {
                return a;
            }
        }
        static BigInt Min(BigInt a, BigInt b)
        {
            if (a > b)
            {
                return b;
            }
            else if (a < b)
            {
                return a;
            }
            else
            {
                return a;
            }
        }
        
        
    }
}
