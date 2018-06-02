using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    class PageReplacement
    {
        int[] pages;
        int[,] pageList;
        int pageLength;
        int pageSize;
        int[] outPage;
        bool[] isInterrupt;
        int sumInterrupt;

        public PageReplacement(int N, int[] P)
        {
            pageLength = P.Length;
            pageSize = N;
            pages = P;
            pageList = new int[pageLength,pageSize];
            outPage = new int[pageLength];
            isInterrupt = new bool[pageLength];           
        }

        public void pageReplacementFIFO()
        {
            sumInterrupt = 0;
            int i,j;
            bool f;
            outPage[0] = -1;
            isInterrupt[0] = false;
            for (i = 0; i < pageSize; i++)
                pageList[0, i] = -1;
            pageList[0, 0] = pages[0];
            for (i = 1; i < pages.Length; i++)
            {
                f = false;
                for (j = 0; j < pageSize; j++)
                {
                    if (f) pageList[i, j] = -1;
                    else if (pageList[i - 1, j] != -1) pageList[i, j] = pageList[i - 1, j];
                    else { pageList[i, j] = pages[i]; f = true; }
                }
                if (f == false)         //pageList is full
                {
                    outPage[i] = pageList[i, 0];
                    isInterrupt[i] = true;
                    for (j = 0; j < pageSize - 1; j++)
                        pageList[i, j] = pageList[i, j + 1];
                    pageList[i, pageSize - 1] = pages[i];
                }
                else
                {
                    outPage[i] = -1;
                    isInterrupt[i] = false;
                }
            }
        }

    }
}
