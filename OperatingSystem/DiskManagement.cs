using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    class DiskManagement
    {
        public int[] cy;
        public int T;
        public int cyNum;
        public int cySortNum;
        public int[] moveNum;
        public int[] cyVisit;
        public int time;
        public int moveLength;
        public double averageLength;

        public DiskManagement(int[] C)
        {
            cy = C;
            cyNum = C.Length;
            cySortNum = C.Length - 1;
            moveNum = new int[cyNum];
            cyVisit = new int[cyNum];
            T = 1;
        }

        public DiskManagement(int[] C, int t)
        {
            cy = C;
            cyNum = C.Length;
            cySortNum = C.Length - 1;
            moveNum = new int[cy.Length];
            cyVisit = new int[cyNum];
            T = t;
        }

        public void diskManagementFIFO()
        {
            int i;
            moveNum[0] = 0;
            cyVisit[0] = cy[0];
            moveLength = 0;
            for (i = 1; i < cyNum; i++)
            {
                cyVisit[i] = cy[i];
                moveNum[i] = Math.Abs(cyVisit[i] - cyVisit[i - 1]);
                moveLength += moveNum[i];
            }
            averageLength = (double)moveLength / (double)cySortNum;
            time = moveLength * T;
        }

        public void diskManagementSSTF()
        {
            int i, j;
            int min, mini;
            int last;
            int[] lent = new int[cyNum];
            int[] cyt = new int[cyNum];
            for (i = 0; i < cyNum; i++) cyt[i] = cy[i];
            moveNum[0] = 0;
            cyVisit[0] = cyt[0];
            moveLength = 0;
            last = cyVisit[0];
            for (i = 1; i < cyNum; i++)
            {
                for (j = 1; j < cyNum; j++)
                    if (cyt[j] != int.MaxValue) lent[j] = Math.Abs(cyt[j] - last); else lent[j] = int.MaxValue;
                min = int.MaxValue; mini = -1;
                for (j = 1; j < cyNum; j++)
                    if (min > lent[j]) { min = lent[j]; mini = j; }
                cyVisit[i] = cyt[mini];
                cyt[mini] = int.MaxValue;
                moveNum[i] = Math.Abs(cyVisit[i] - cyVisit[i - 1]);
                moveLength += moveNum[i];
            }
            averageLength = (double)moveLength / (double)cySortNum;
            time = moveLength * T;
        }

        public void diskManagementELEVU()
        {
            int i;
            int l = 0, r = 0;
            int n = 0;
            int[] cyt = new int[cyNum];
            for (i = 0; i < cyNum; i++) cyt[i] = cy[i];
            Array.Sort(cyt);
            for (i = 0; i < cyNum; i++) if (cyt[i] == cy[0]) l = i;
            for (i = cyNum - 1; i >= 0; i--) if (cyt[i] == cy[0]) r = i;
            for (i = l; i <= r; i++) cyVisit[n++] = cyt[i];
            for (i = r + 1; i < cyNum; i++) cyVisit[n++] = cyt[i];
            for (i = l - 1; i >= 0; i--) cyVisit[n++] = cyt[i];
            for (i = 1; i < cyNum; i++)
            {
                moveNum[i] = Math.Abs(cyVisit[i] - cyVisit[i - 1]);
                moveLength += moveNum[i];
            }
            averageLength = (double)moveLength / (double)cySortNum;
            time = moveLength * T;
        }

        public void diskManagementELEVD()
        {
            int i;
            int l = 0, r = 0;
            int n = 0;
            int[] cyt = new int[cyNum];
            for (i = 0; i < cyNum; i++) cyt[i] = cy[i];
            Array.Sort(cyt);
            for (i = 0; i < cyNum; i++) if (cyt[i] == cy[0]) l = i;
            for (i = cyNum - 1; i >= 0; i--) if (cyt[i] == cy[0]) r = i;
            for (i = l; i <= r; i++) cyVisit[n++] = cyt[i];
            for (i = l - 1; i >= 0; i--) cyVisit[n++] = cyt[i];
            for (i = r + 1; i < cyNum; i++) cyVisit[n++] = cyt[i];
            for (i = 1; i < cyNum; i++)
            {
                moveNum[i] = Math.Abs(cyVisit[i] - cyVisit[i - 1]);
                moveLength += moveNum[i];
            }
            averageLength = (double)moveLength / (double)cySortNum;
            time = moveLength * T;
        }

    }
}
