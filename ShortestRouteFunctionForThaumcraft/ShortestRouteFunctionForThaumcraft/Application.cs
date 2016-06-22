using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestRouteFunctionForThaumcraft
{
    public class Application
    {
        private Dictionary<string, List<string>> AspectMap = new Dictionary<string, List<string>>(){
            { "Perditio", new List<string>(){ "Vitium", "Vacuos", "Vinculum", "Venenum", "Mortuus", "Permutatio", "Gelum" } }
            , { "Aer", new List<string>(){ "Lux", "Vacuos", "Auram", "Sensus", "Volatus", "Motus", "Arbor", "Tempestas" } }
            , { "Ignis", new List<string>(){ "Lux", "Potentia", "Gelum", "Cognitio", "Telum", /*"Ira" *//*, "Infernus"*/ } }
            , { "Aqua", new List<string>(){ "Tempestas", "Venenum", "Victus", "Limus" } }
            , { "Terra", new List<string>(){ "Victus", "Iter", "Metallum", "Perfodio", "Vitreus", "Herba", "Tutamen" } }
            , { "Ordo", new List<string>(){ "Potentia", "Sano", "Motus", "Permutatio", "Instrumentum", "Vitreus", } }
            , { "Vacuos", new List<string>(){ "Perditio", "Aer", "Alienis", "Tenebrae", "Praecantatio", "Fames" } }
            , { "Lux", new List<string>(){ "Aer", "Ignis", "Tenebrae" } }
            , { "Potentia", new List<string>(){ "Ignis", "Ordo", "Praecantatio" } }
            , { "Tempestas", new List<string>(){ "Aqua", "Aer" } }
            , { "Victus", new List<string>(){ "Fames", "Mortuus", "Sano", "Spiritus", "Bestia", "Limus", "Herba", "Aqua" } }
            , { "Mortuus", new List<string>(){ "Perditio", "Victus", "Corpus", "Spiritus", "Exanimis" } }
            , { "Sano", new List<string>(){ "Victus", "Ordo" } }
            , { "Motus", new List<string>(){ "Aer", "Ordo", "Vinculum", "Volatus", "Exanimis", "Machina", "Bestia", "Iter" } }
            , { "Limus", new List<string>(){ "Victus", "Aqua" } }
            , { "Gelum", new List<string>(){ "Perditio", "Ignis" } }
            , { "Metallum", new List<string>(){"Vitreus", "Terra"} }
            , { "Vitreus", new List<string>(){ "Metallum", "Ordo", "Terra" } }
            , { "Herba", new List<string>(){ "Victus", "Arbor", "Terra", "Messis" } }
            , { "Arbor", new List<string>(){ "Herba", "Aer" } }
            , { "Tutamen", new List<string>(){ "Instrumentum", "Terra" } }
            , { "Perfodio", new List<string>(){ "Terra", "Humanus" } }
            , { "Messis", new List<string>(){ "Herba", "Humanus" , "Meto" } }
            , { "Meto", new List<string>(){ "Instrumentum", "Messis" } }
            , { "Iter", new List<string>(){ "Motus", "Terra" } }
            , { "Permutatio", new List<string>(){ "Perditio", "Ordo" } }
            , { "Cognitio", new List<string>(){ "Spiritus", "Ignis", "Humanus" } }
            , { "Humanus", new List<string>(){ "Bestia", "Cognitio", "Lucrum", "Instrumentum", "Fabrico", "Messis", "Perfodio" } }
            , { "Fabrico", new List<string>(){ "Instrumentum", "Humanus" } }
            , { "Instrumentum", new List<string>(){ "Humanus", "Ordo", "Telum", "Machina", "Pannus", "Fabrico", "Meto", "Tutamen" } }
            , { "Pannus", new List<string>(){ "Instrumentum", "Bestia" } }
            , { "Lucrum", new List<string>(){ "Fames", "Humanus" } }
            , { "Machina", new List<string>(){ "Instrumentum", "Motus" } }
            , { "Telum", new List<string>(){ "Instrumentum", "Ignis", /*"Ira" */} }
            , { "Bestia", new List<string>(){ "Motus", "Victus", "Corpus", "Pannus", "Humanus" } }
            , { "Exanimis", new List<string>(){ "Motus", "Mortuus" } }
            , { "Spiritus", new List<string>(){ "Mortuus", "Victus", "Sensus", "Cognitio" } }
            , { "Volatus", new List<string>(){ "Aer", "Ordo" } }
            , { "Corpus", new List<string>(){ "Mortuus", "Bestia" } }
            , { "Venenum", new List<string>(){ "Aqua", "Perditio" } }
            , { "Vinculum", new List<string>(){ "Motus", "Perditio" } }
            , { "Sensus", new List<string>(){ "Aer", "Spiritus"/*, "Invidia"*/ } }
            , { "Fames", new List<string>(){ "Lucrum", "Vacuos", "Victus"/*, "Invidia"*/ } }
            , { "Auram", new List<string>(){ "Aer", "Praecantatio" } }
            , { "Praecantatio", new List<string>(){ "Vacuos", "Potentia", "Vitium", "Auram", /*"Infernus"*/ } }
            , { "Vitium", new List<string>(){ "Praecantatio", "Perditio" } }
            , { "Tenebrae", new List<string>(){ "Vacuos", "Lux", "Alienis" } }
            , { "Alienis", new List<string>(){ "Vacuos", "Tenebrae" } }
            //, { "Invidia", new List<string>(){ "Sensus", "Fames" } }
            //, { "Infernus", new List<string>(){ "Ignis", "Praecantatio" } }
            //, { "Ira", new List<string>(){ "Telum", "Ignis" } }
        };

        //private Dictionary<string, List<string>> aspectSourceMap = null;
        //public Dictionary<string, List<string>> AspectSourceMap
        //{
        //    get
        //    {
        //        if(aspectSourceMap == null)
        //        {
        //            aspectSourceMap = MapAspectSources();
        //        }

        //        return aspectSourceMap;

        //    }
        //}

        //private Dictionary<string, List<string>> MapAspectSources()
        //{
        //    Dictionary<string, List<string>> aspects = AspectMap.Where(a => a.Value.Count == 2).ToDictionary(a => a.Key, b => b.Value);

        //}


        public void PromptForShortestChain()
        {
            string startingAspect;
            string endingAspect;
            int requiredHops;
            do
            {
                Console.Write("Please enter the name of the starting Aspect: ");
                startingAspect = Console.ReadLine();

                if (!AspectMap.ContainsKey(startingAspect))
                {
                    Console.WriteLine("NOTICE: your starting Aspect does not exist..");
                    continue;
                }

                Console.Write("\nPlease enter the name of the ending Aspect: ");
                endingAspect = Console.ReadLine();

                if (!AspectMap.ContainsKey(endingAspect))
                {
                    Console.WriteLine("NOTICE: your ending Aspect does not exist..");
                    continue;
                }

                Console.Write("\nPlease enter the number of spaces: ");
                try
                {
                    requiredHops = int.Parse(Console.ReadLine());
                }
                catch(Exception)
                {
                    Console.Write("\nParse failed, shortest path option selected. ");
                    requiredHops = 0;

                }
                // run a recursive loop through dictionary from starting aspect to the shortest route.
                // print the names of the apsects in order from start to end.

                List<string> aspectChain = AspectRouteFinder(startingAspect, endingAspect, requiredHops);

                Console.Write("\n\nShortest chain: ");
                foreach (string aspect in aspectChain)
                {
                    Console.Write(" > " + aspect);
                }

                Console.Write("\n\n");
            }
            while (Prompt4Continue());
        }

        private bool Prompt4Continue ()
        {
            Console.Write("\nContinue? (y/n): ");
            string answer = Console.ReadLine();
            Console.Write("\n\n");

            return answer == "y";
        }

        private List<string> AspectRouteFinder (string first, string last, int hops)
        {
            //start a chain with the first aspect, pass chain to recursive function.
            // recursive function takes list of aspects, the name of the last element, and ... just write the damn thing...
            List<string> finalList = RouteHelper(first, last, new List<string>(), hops);
            finalList.Add(first);
            finalList.Reverse();
            return finalList;

        }

        private List<string> RouteHelper (string currentAspect, string final, List<string> AlreadyVisited, int hops = 0)
        {
            List<string> aspectConnections = new List<string>();
            aspectConnections.AddRange(AspectMap[currentAspect]);

            AlreadyVisited.Add(currentAspect);

            if (aspectConnections.Contains(final))
            {
                return new List<string>() { final };
            }

            aspectConnections.RemoveAll(a => AlreadyVisited.Contains(a));

            if (aspectConnections.Count == 0)
            {
                return null;
            }

            List<string> shortRoute = null;
            List<string> tempRoute = null;
            string shortestAspect = null;

            for (int i = 0; i < aspectConnections.Count; i++)
            {
                string aspect = aspectConnections[i];

                AlreadyVisited.Add(aspect);
                List<string> set = new List<string>();
                set.AddRange(AlreadyVisited);

                tempRoute = RouteHelper(aspect, final, set);

                if ((shortRoute == null && tempRoute != null)
                    || (shortRoute != null
                        && tempRoute != null
                        && ((shortRoute.Count > hops
                                && tempRoute.Count >= hops
                                && tempRoute.Count < shortRoute.Count)
                            ||(shortRoute.Count < hops
                               && tempRoute.Count <= hops
                               && tempRoute.Count > shortRoute.Count)
                            )
                        )
                    )
                {
                    shortestAspect = aspect;
                    shortRoute = tempRoute;
                }
            }

            if (shortRoute != null)
            {
                shortRoute.Add(shortestAspect);
            }

            return shortRoute;
        }
    }
}
