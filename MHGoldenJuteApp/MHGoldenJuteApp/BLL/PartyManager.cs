using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MHGoldenJuteApp.DAL;
using MHGoldenJuteApp.Models;

namespace MHGoldenJuteApp.BLL
{
    public class PartyManager
    {
        PartyAccess aPartyAccess = new PartyAccess();

        public int Save(Party aParty)
        {
            if (aPartyAccess.IsPartyNameExist(aParty.PartyName,aParty.PartyType)) return 3;
            else
            return aPartyAccess.Save(aParty);
        }

        public Party GetAPartyById(int partyID)
        {
            return aPartyAccess.GetAPartyById(partyID);
        }

        public List<Party>GetAllParty()
        {
            return aPartyAccess.GetAllParty();
        }

        public int Update(Party aParty)
        {
            return aPartyAccess.UpdateAParty(aParty);
        }

        public int DeleteById(int partyId)
        {
            return aPartyAccess.DeleteById(partyId);
        }
    }
}