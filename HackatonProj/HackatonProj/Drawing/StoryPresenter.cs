using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonProj.Logics;
using SFML.Graphics;
using SFML.System;

namespace HackatonProj.Drawing
{
    /// <summary>
    /// Use the iterator to iterate through collection of story pages.
    /// </summary>
    public class StoryPresenter : IEnumerable<Tuple<Text, int>>
    {
        //The key is the page, the value - duration of the page.
        private LinkedList<Tuple<Text, int>> storyPages = new LinkedList<Tuple<Text, int>>();
        private FontLoader fontLoader = new FontLoader();

        private readonly string storyPage1 = "E.U.V.I.C. - Elite Unit of Vindication In Crysis - has sent \n" +
                                                   "its best Vindicators to help people of AEInf sector and save them \n" +
                                                   "from cruel fate.";

        private const int showTime = 10;
        private const int fontSize = 20;

        private readonly string storyPage2 = "U.L.A. - the ominous, fearsome Universal Life-form Annihilator \n" +
                                             "the master of Binarium Gates, wants to bury the last sparks of hope \n" +
                                             "in this sector.";

        private readonly string storyPage3 = "Dear Vindicators. You are about to enter the enemy domain. \n" +
                                             "The final destination point. \n" +
                                             "Fate of the students is in your hands.";

        private readonly string storyPage4 = "MAY THE GC BE WITH YOU! \n" +
                                             "Good luck.";

        private Text CreateText(string text, Font font, int charSize, Color fillColor)
        {
            Text storyline = new Text(storyPage1, fontLoader.GetFont(), fontSize);
            storyline.Color = fillColor;

            return new Text(storyline);
        }
        public StoryPresenter()
        {
            storyPages.AddLast(Tuple.Create(CreateText(storyPage1, fontLoader.GetFont(), fontSize, Color.White), showTime));
            storyPages.AddLast(Tuple.Create(CreateText(storyPage2, fontLoader.GetFont(), fontSize, Color.White), showTime));
            storyPages.AddLast(Tuple.Create(CreateText(storyPage3, fontLoader.GetFont(), fontSize, Color.White), showTime));
            storyPages.AddLast(Tuple.Create(CreateText(storyPage4, fontLoader.GetFont(), fontSize, Color.White), showTime));
        }
        


        public IEnumerator<Tuple<Text, int>> GetEnumerator()
        {
            return storyPages.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void WaitForNextPage(int timeInSeconds)
        {
            Clock clock = new Clock();
            while (clock.ElapsedTime.AsSeconds() < timeInSeconds) ; //Wait for given amount of time
        }
    }
}
