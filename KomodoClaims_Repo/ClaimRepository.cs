using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Repo
{
    public class ClaimRepository
    {
        //For this repo we create a Queue
        public Queue<ClaimsContent> _QueueOfClaims = new Queue<ClaimsContent>();

        public Queue<ClaimsContent> GetClaims()
        {
            return this._QueueOfClaims;
        }

        //Create
        public void AddNewClaim(ClaimsContent content)
        {
            _QueueOfClaims.Enqueue(content);
        }

        //Read 



        //Update


        //Delete
    }
}
