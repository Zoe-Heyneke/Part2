using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProgramPart1;

namespace Part2
{
    public class Recipes
    {
        public Recipes()
        {
            this.Ingredients = new List<Ingredients>();
            this.recSteps = new List<string>();
        }
        public string recName //property
        { get; set; }  //get and set method to access value of private
        public List<Ingredients> Ingredients //property
        { get; set; }   //get and set method to access value of private
        public List<string> recSteps //property
        { get; set; }   //get and set method to access value of private

        //potential fix:public object Ingredients { get; internal set; }
    }
}
