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
        private Queue<ClaimsContent> _QueueOfClaims = new Queue<ClaimsContent>();

        //Create
        public void AddNewClaim(ClaimsContent content)
        {
            _QueueOfClaims.Enqueue(content);
        }

        //Read 
        public Queue<ClaimsContent> GetClaims()
        {
            return _QueueOfClaims;
        }

        //Update - No update needed


        //Delete - No delete needed

    }
}
