using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle
{
    public interface IHeadquarters
    {
        Guid ReportEnlistment(string soldierName);

        void ReportCasualty(int soldierId);

        void ReportVictory(int remainingNumberOfSoldiers);
    }
}
