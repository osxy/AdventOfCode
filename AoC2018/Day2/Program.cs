using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Do JIT compilation
            PartOne();
            PartTwo();
            Console.Clear();


            Stopwatch watch = Stopwatch.StartNew();
            Console.WriteLine("Day Two - Part One");
            watch.Restart();
            PartOne();
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            Console.WriteLine("");

            Console.WriteLine("Day Two - Part Two");
            watch.Restart();
            PartTwo();
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            //Keep console open untill any value is returned
            Console.ReadLine();


        }


        static void PartOne()
        {

            ExecutePartOne(realInputValues);

        }

        static void PartTwo()
        {

            ExecutePartTwo(realInputValues);

        }


        static void ExecutePartTwo(string[] input)
        {

            var letters = new Dictionary<string, Int16>();
            var matchingString = new List<string>();
            var minFoundDiff = new Tuple<int, string>(0,"");


            // Loop door elke string heen
            foreach (string value in input)
            {

                letters.Clear();

                foreach (string character in value.ToCharArray().Select(c => c.ToString()).ToArray())
                {
                    if (letters.ContainsKey(character))
                    {
                        letters[character] += 1;
                    }
                    else
                    {
                        letters.Add(character, 1);
                    }
                }

                // Als er één van de letters 2 of 3 keer voorkomt toevoegen aan de matchingstring list
                if (letters.ContainsValue(3) || letters.ContainsValue(2))
                {
                    matchingString.Add(value);
                }

            }

            // Loop door elke string heen met 2x / 3x zelfde letter
            foreach (string a in matchingString)
            {

                // Loop door elke string heen met 2x / 3x zelfde letter om a te vergelijken met elke andere waarde in de array
                foreach (string b in matchingString)
                {
                    // Alleen verwerken als string niet gelijk is
                    if (a != b)
                    {
                        var diff = CompareStrings(a, b);
                        // Als er nog geen minFoundDiff is of de minFoundDiff is groter dan nieuwe gevonden diff
                        if (minFoundDiff.Item1 > diff.Item1 || minFoundDiff.Item1 == 0)
                        {
                            minFoundDiff = diff;
                            //Console.WriteLine(diff.Item2);
                            //Console.WriteLine(a);
                            //Console.WriteLine(b);
                        }
                        
                    }

                }

            }
            Console.WriteLine(minFoundDiff.Item2);

        }

        static void ExecutePartOne(string[] input)
        {

            int forcount = 1;
            var letters = new Dictionary<string, int>();
            var twoCount = new Dictionary<string, int>();
            var threeCount = new Dictionary<string, int>();
            var twoTotal = new Dictionary<int, int>();
            var threeTotal = new Dictionary<int, int>();


            // Loop door elke string heen
            foreach (string value in input)
            {

                letters.Clear();
                twoCount.Clear();
                threeCount.Clear();               

                foreach (string character in value.ToCharArray().Select(c => c.ToString()).ToArray())
                {


                    if(letters.ContainsKey(character))
                    {

                        letters[character] += 1;

                    } else
                    {

                        letters.Add(character, 1);

                    }

                }

                // Als er een letter is gevonden welke exact 3x voorkomen tel dan 1 op bij 3xcounter
                if (letters.ContainsValue(3))
                {
                    twoTotal.Add(forcount, 0);

                }

                // Als er een letter is gevonden welke exact 2x voorkomen tel dan 1 op bij 2xcounter
                if (letters.ContainsValue(2))
                {
                    threeTotal.Add(forcount, 0);
                }
                ++forcount;

            }


            Console.WriteLine(twoTotal.Count * threeTotal.Count);

        }

        static Tuple<int, string> CompareStrings(string a, string b)
        {
            int diff = 0;
            string remainingString = "";

            // Zet a om in een Char Array
            var ArrayA = new string[0];
            ArrayA = a.ToCharArray().Select(c => c.ToString()).ToArray();

            // Zet b om in een Char Array
            var ArrayB = new string[0];
            ArrayB = b.ToCharArray().Select(c => c.ToString()).ToArray();

            for (int i = 0; i < ArrayA.Count(); i++)
            {

                // Als character op positie i in a en b niet gelijk is tel dan 1 op bij de diff counter
                if (ArrayA[i] != ArrayB[i])
                {
                    diff += 1;

                } else { // Als het character op positie i in a en b gelijk is bouw dan de nieuwe return string op

                    remainingString = remainingString + ArrayA[i];

                }
            }

            return Tuple.Create(diff, remainingString);
        }

        //Inputs
        static readonly string[] inputValuesTest1 = new string[]
        {
            "abcdabcabbqq", // 2x q, 3x a, 2x c
            "abccc", // 3x c
            "abbaab", //3x a, 3x b
            "abcdefg", // geen
            "abcdabcabbqq", // 2x q, 3x a, 2x c
            "abccc", // 3x c
            "abcdefg" // geen
        };

        static readonly string[] inputValuesTest2 = new string[]
        {
            "qwugbihrkplyzcjahefttvdzns",
            "qwugbihrkppzzcjahefttvdzns",
            "qwugbihrkppzzzjahefttvdzns",
            "qwugbihrkplyzcjaheftttdzns"
        };

        static readonly string[] realInputValues = new string[]
        {
            "qwubbihrkplymcraxefntvdzns",
            "qwugbihrkplyzcjahefttvdzns",
            "qwugbihrkplymcjoxrsotvdzns",
            "qwugbphrkplympjaxmfotvdzns",
            "qwugbghrkpltbcjaxefotvdzns",
            "qwubbihrwpuymcjaxefotvdzns",
            "qiugpihrkplymcwaxefotvdzns",
            "qwugbihrkplymcjavefotvotns",
            "qwugbihrkpvymcjaxefotvnzes",
            "qwvgbihrkpltmcnaxefotvdzns",
            "qwugvihrkplymvjaxefotvczns",
            "qwugbihrkplymwjazefotvyzns",
            "qwugbihrkplbmcjbxefttvdzns",
            "qhugbihrkplymcjaxefotnazns",
            "qwugbihrkpyyacjacefotvdzns",
            "qwugsihrkpsymcjaxafotvdzns",
            "qwugbihriplymcjixefosvdzns",
            "qwuibihrkjlvmcjaxefotvdzns",
            "qwugbjhrgplymcjaxefotvdzys",
            "qwugnimrkplymcjayefotvdzns",
            "qwumjihrkplymcjexefotvdzns",
            "qwugbihukptymcjaxefotvvzns",
            "qwughthrgplymcjaxefotvdzns",
            "qlugbihrkplymcjbxhfotvdzns",
            "qhugbiyrkplymcjaxefotvdzes",
            "qwugbihrkvlymcjaxecotvtzns",
            "qwugbihrkphymcjaxefitvizns",
            "qwugbbhdtplymcjaxefotvdzns",
            "qwugbihrkplymceaxefotvltns",
            "mwugbihrkptymcpaxefotvdzns",
            "qwugbihrdplymcvaxefotvdwns",
            "qwugbihrkplymcjaxekhtvhzns",
            "qjugbihrkplyjcjaxefonvdzns",
            "qwugbihrjplymcjaxefgtudzns",
            "qlugbihrkplymcjaxefztvdpns",
            "qwugbihrkclyvpjaxefotvdzns",
            "qwugbihrsplymnjhxefotvdzns",
            "qwudbihrbxlymcjaxefotvdzns",
            "qwugbihrkplymcjxxefatvdzng",
            "qwujbihrkplyqdjaxefotvdzns",
            "qwugnihrkplamcjaxefotvmzns",
            "qwugnihrkplymcjajekotvdzns",
            "qwugbihrkslymcjamsfotvdzns",
            "fwugbihrkplymcjaxetotvdzne",
            "qwughihrkplyucfaxefotvdzns",
            "qwuebihrkplymcraxefotvdzgs",
            "qwugbinrkplymcjaxefodvdznh",
            "qwudbihrkplymcjsxefotvjzns",
            "qwlgbihrkzlymcjixefotvdzns",
            "qwugbihckpoymcpaxefotvdzns",
            "qwfgbibskplymcjaxefotvdzns",
            "qwugbihrkplymczaxdfotvuzns",
            "qwugbihwkplymcjaxepxtvdzns",
            "qwubbihrkplymcjaxefntfdzns",
            "qwunbihrkpaymcjaxefotvdzni",
            "qwugfihrkplymujaxefotvdzni",
            "qwugrihrkplymkjaxxfotvdzns",
            "ztugbihrkplymcjaxefotvdznt",
            "qwugbihrkplvmcjaxefotvdzph",
            "qwugtinrfplymcjaxefotvdzns",
            "qwugbihrkplamcjkmefotvdzns",
            "qwtgbihryplymcjaxeeotvdzns",
            "qwugbiazkplymhjaxefotvdzns",
            "pwugbihrkplymklaxefotvdzns",
            "wwugbihkxplymcjaxefotvdzns",
            "dwugbihrgpdymcjaxefotvdzns",
            "qwulbihrkplymcjaxefoqvqzns",
            "qvugbihrkplyhcjtxefotvdzns",
            "qwugbihrkplymcjaxcfotvfzjs",
            "qwugbihrkpkymyjaxdfotvdzns",
            "qwugbinrkplymcjswefotvdzns",
            "qcuguiqrkplymcjaxefotvdzns",
            "qwugbihlkplyccjaxefrtvdzns",
            "qwugbihpkplomcjaxefotvdhns",
            "qwggbphrkplymcjaxbfotvdzns",
            "qwuipihrkplymcjaxefotvdznt",
            "qwugbihrhplyccjaxeforvdzns",
            "qwugbdhrkplymcjdxefotvdznv",
            "qwugbihrkplymcjaxefotvbfos",
            "qwugtihrkplymcocxefotvdzns",
            "qwugbihrkpljmcjaxwfovvdzns",
            "qwugbnhrkplymcjaxefotvdxnm",
            "qwugbihrkpeymcjauefotvlzns",
            "qwugbihjkplymcraxefftvdzns",
            "qwugbghrkplymcjaxefotvizni",
            "qwwgbihrkplymcjrxefotvrzns",
            "qwugbihrkplymzjawexotvdzns",
            "qwugnihrkplymcjpxnfotvdzns",
            "qwugbihrkdlytcjaxecotvdzns",
            "qwugbihrkacymdjaxefotvdzns",
            "qlugbehrkplymcjaxzfotvdzns",
            "fwugbihrkplymcjamefotldzns",
            "qwugbihrkplymcjarefotlszns",
            "qwsgbihrkpnymcjfxefotvdzns",
            "awuubihrkplymcjaxefrtvdzns",
            "qwngbihrkpjtmcjaxefotvdzns",
            "qwugbihrkpltmkjaxefytvdzns",
            "ewugbihrkplymcjvxefotvdzus",
            "qwugbihrpplymcjaxsfmtvdzns",
            "qwrgbihrmplymcjaxefutvdzns",
            "qwugbihrknxymcwaxefotvdzns",
            "qwugbnurkplymcjabefotvdzns",
            "qwugbihrkphomfjaxefotvdzns",
            "qwugbchrkplymcjaxefctvdens",
            "qwugbidrkplymcjaxefotwwzns",
            "qwggbohrkplgmcjaxefotvdzns",
            "nwkgbihrkplymcjaxqfotvdzns",
            "qwuibihrkpnymajaxefotvdzns",
            "qwugsihrzplymujaxefotvdzns",
            "qwugbihrkplumcgaxefodvdzns",
            "qwugbqhrkplymcjaxefotvddts",
            "qwugbiorkpvyacjaxefotvdzns",
            "bjugbihukplymcjaxefotvdzns",
            "qwugbyhrkplymxjaxexotvdzns",
            "vwugbihrkplymcraxefotgdzns",
            "qwugbihrkplymjwaxeaotvdzns",
            "qwpsbihrkplykcjaxefotvdzns",
            "qwugbqhrkplymcjaxefotgdzno",
            "qwugbjhrkplymcjaxefatvczns",
            "qwuglihrkclymcjvxefotvdzns",
            "qjugbihrkpsymcjajefotvdzns",
            "qwugbinrkptymcjaxedotvdzns",
            "qwurbihrkglymcjaxefomvdzns",
            "qfugbihrsxlymcjaxefotvdzns",
            "lwuggihrkplymcjaxefotvdzds",
            "qwugbihrkplymcjhxwfjtvdzns",
            "qwugbhjrkplymcjaxefotvdyns",
            "qwugbihrkplymcjoxefepvdzns",
            "awwgbihryplymcjaxefotvdzns",
            "qpugbihrkplymcjaxekorvdzns",
            "qwulbihrkplymcuapefotvdzns",
            "qwugbwhrkplymljaxefotvdrns",
            "qwugxihrkplymjjalefotvdzns",
            "qwugbmhrkplymcjyxefotvdnns",
            "qwugbihrkplymcjnxgfotsdzns",
            "qwygbihrkplsmczaxefotvdzns",
            "qwugbihrkplymqjaxefovgdzns",
            "qwuwbihrkplymcjaxefktvdznu",
            "qwugbihrkplyfcjaxeoowvdzns",
            "qwufbiyrkplymcjaxedotvdzns",
            "qwusbirrkplymcjaxefotvdlns",
            "qwurbihroplymtjaxefotvdzns",
            "qiugbihrkplymcjaxefvtvmzns",
            "qwugrihrkflymcjaxefotvdzls",
            "qwugbimrzplymcoaxefotvdzns",
            "qyugbiwrkplymcjasefotvdzns",
            "qwubbihrkpiymcjaxefotvdzws",
            "qwugbilrkplymjjgxefotvdzns",
            "qwugbihykplympjaxefotgdzns",
            "qwugmxhrkplymcjaxefotvdins",
            "qwfjbahrkplymcjaxefotvdzns",
            "owuzbihrkplymcbaxefotvdzns",
            "qwugbihrkilymcjaxefotsdzvs",
            "qwugbwhrkplymcpzxefotvdzns",
            "qwugbihrkplymcjlcefotvdjns",
            "kwugbihrkplymcjaxefotvhdns",
            "qwulbihrkplymcfwxefotvdzns",
            "qwxabihrkplyhcjaxefotvdzns",
            "qwugbihrzpoymcjaxefotqdzns",
            "qwugbihrknlymcjabefovvdzns",
            "qyugbihrkplymclaxefotvgzns",
            "qwugbxhrkpgymcjaxefotvdlns",
            "qwuplihrkplymcjaxefhtvdzns",
            "qwugbihruplymcjaxefotmdzps",
            "qwugkihrkplymcqtxefotvdzns",
            "qwugbihrkplymcjaxeyodvszns",
            "qwukbihrkplymojaxefotvczns",
            "nwugbihrkplymcjaxrfothdzns",
            "qwugbihrkklymcjaxqfotvdzcs",
            "qwugbihrkplemcjaxefotvufns",
            "qwugbihrkplymcjaxbfitvdzne",
            "qwugbizrkplymcjaxgfotvdhns",
            "qwulbihrxplymcjaxefolvdzns",
            "jwugbihckpoymcpaxefotvdzns",
            "qwugeihrkplymbjcxefotvdzns",
            "qwuxbihbkplymcjaxeuotvdzns",
            "qwugbshrkplyvcjlxefotvdzns",
            "qwugbimrjplymcjaxtfotvdzns",
            "qwugzikrkplymcjaxefxtvdzns",
            "qwugbihrkplymcjaxefftvdgnq",
            "qwugbihnkilymcjaxemotvdzns",
            "qfugbihrkplyfcjadefotvdzns",
            "qwugbihrkplymrsaxefwtvdzns",
            "qwugfihrkpsymckaxefotvdzns",
            "qwulbihrkplymyjaxefotvdkns",
            "quugbikrkpkymcjaxefotvdzns",
            "qwugbihfgplymdjaxefotvdzns",
            "qougbihrkplemcjaqefotvdzns",
            "qwugbihrkplemcjjxefotvdyns",
            "qfuhbikrkplymcjaxefotvdzns",
            "qhugbihrcplymcjaxefrtvdzns",
            "qwugbmhnkplymcjnxefotvdzns",
            "qwugbihrkplymmjaaefofvdzns",
            "qwugbihrtplykcjaxefoxvdzns",
            "qwugbihrkmvymcjaxefetvdzns",
            "qwugbfjrkplymcjaxefotadzns",
            "qwuibihrrplymcjaxefotvdznv",
            "qwcgbihrkjlymcjzxefotvdzns",
            "qwugbihrkplymcjuxefytvzzns",
            "qwkgwihrkllymcjaxefotvdzns",
            "qwugbihrkplymcpaxgfogvdzns",
            "qwuvbihrkplymcdaxefotvdmns",
            "qwtgbihrkplqmcjgxefotvdzns",
            "qwuglihrkplnmcjaxefptvdzns",
            "qbugbihrkplymcjawefotidzns",
            "qwegbihrvplymcjaxefqtvdzns",
            "qwugbihrgqlyncjaxefotvdzns",
            "qwugbihrpplymcjaxefotvdeqs",
            "qwugbihrkplypzjaxefbtvdzns",
            "qwugbihrkpkyncjanefotvdzns",
            "qwugbshrkplymcjaxefotfdzys",
            "qwugbihrkpymmcjaxefotzdzns",
            "qwugbphrkplymcjaxefotvdzru",
            "qyugbihrkplamcjjxefotvdzns",
            "qwugbihrmphymcjaxefotedzns",
            "qwuafihrkplymcjaxefozvdzns",
            "qwugwihrkplymcjaxwfotvdzws",
            "qwugbihrkzlymcjaxjfotvdznz",
            "uwugsihrkplypcjaxefotvdzns",
            "qwugbihrkplymcjaxefotudzur",
            "qwugbihrkplymcjoxefotfdzng",
            "qwugbihxkplymcjamebotvdzns",
            "qpugvihrkplymcjaxefotvdzhs",
            "qwugbihrkplyocgaxefotvdzss",
            "qwugbihrkplymcpaqekotvdzns",
            "qwunbihrkplymclaxefitvdzns",
            "qzugbihrkplsmcjaxebotvdzns",
            "qvugbihrkplymcjsxefotvmzns",
            "qwugbihrkprymcyaxkfotvdzns",
            "qwugbihukplymcjaxefotzlzns",
            "qwusbihrkplymcjaxwfotxdzns",
            "qwugbihrwplymcjaxefbtcdzns",
            "qwugbihrkplymcjpxefotkdons",
            "qwugbihrkhlymcjaxefohvwzns",
            "qwukbihrkplymxjaxefotvdzms",
            "qwugbiprkplsmcjaxefotvdznm",
            "qwugbqhrkplymcjawwfotvdzns",
            "qwugbihrkprymcjaxefotvdxnb",
            "qwugbihrkplymcjaxefoivpzos",
            "qwugbuhrkplymcjaxefotvdzsb",
            "qwugblhrcplymcjaxefotvdyns",
            "qtuabihrkplymejaxefotvdzns",
            "qwucbihrkplyvcjaxefotvdznu",
            "rwugbyhrkplymcjaxefotvdzrs",
            "qruybihrkpsymcjaxefotvdzns",
            "qwugbihrjpwymcjaxejotvdzns",
            "qwugbihshplymcjaxefoavdzns",
            "vwugbihrkplymwjaxefotvdznc",
            "qwugbihrkpmymcjvxcfotvdzns",
            "qkxgbihrkplymcjnxefotvdzns"
        };

    }
}
