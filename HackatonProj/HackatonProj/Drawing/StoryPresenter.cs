using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonProj.Logics;
using SFML.Graphics;

namespace HackatonProj.Drawing
{
    class StoryPresenter
    {
        private FontLoader fontLoader = new FontLoader();
        public enum storyPages { Page1, Page2, Page3, Page4}

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

        private Text storyline;

        private static StoryPresenter _instance;

        private StoryPresenter()
        {
            storyline = new Text("", fontLoader.GetFont(), fontSize);
        }

        private static StoryPresenter GetInstance()
        {
            if (_instance == null)
            {
                _instance = new StoryPresenter();
            }

            return _instance;
        }


        /// <summary>
        /// Returns a text object that contains story of the game.
        /// </summary>
        /// <returns>A reference to Text object that contains the story and time, in seconds,
        /// for which the story shall bve presented to player.</returns>
        public static Tuple<Text, int> PresentStory(storyPages pageIndex)
        {
            StoryPresenter instance = GetInstance();
            switch (pageIndex)
            {
                case storyPages.Page1:
                    instance.storyline = new Text(instance.storyPage1, instance.fontLoader.GetFont(), fontSize);
                    break;
                case storyPages.Page2:
                    instance.storyline = new Text(instance.storyPage2, instance.fontLoader.GetFont(), fontSize);
                    break;
                case storyPages.Page3:
                    instance.storyline = new Text(instance.storyPage3, instance.fontLoader.GetFont(), fontSize);
                    break;
                case storyPages.Page4:
                    instance.storyline = new Text(instance.storyPage4, instance.fontLoader.GetFont(), fontSize);
                    break;
            }
            return Tuple.Create<Text, int>(instance.storyline, showTime);
        }
    }
}
