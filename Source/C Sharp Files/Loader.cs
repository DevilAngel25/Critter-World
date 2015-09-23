using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CritterBrainBase;

namespace Critters
{
    public class Loader : ICritterFactory2
    {
        //create a list of my critters.
        public List<CritterBrainCore> NewBrains = new List<CritterBrainCore> { new Runner(), new Survivor() };
        
        public IEnumerable<CritterBrainCore> GetCritterBrains()
        {
            //send the list of critters to the critterbrain.
            return NewBrains;
        }
    }
}
