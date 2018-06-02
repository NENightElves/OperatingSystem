using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    class PageReplacement
    {
        public int[] pages;
        public int[,] pageList;
        public int pageLength;
        public int pageSize;
        public int[] outPage;
        public bool[] isInterrupt;
        public int sumInterrupt;
        public double percent;

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
            int location;
            bool f;
            outPage[0] = -1;
            isInterrupt[0] = false;
            for (i = 0; i < pageSize; i++)
            {
                pageList[0, i] = -1;
                outPage[i] = -1;
            }
            pageList[0, 0] = pages[0];
            sumInterrupt++;
            isInterrupt[0] = true;
            for (i = 1; i < pages.Length; i++)
            {
                f = true;
                location = -1;
                for (j = 0; j < pageSize; j++)
                {
                    if (pageList[i - 1, j] == pages[i]) f = false;
                    if (location == -1 && pageList[i - 1, j] == -1) location = j;
                    pageList[i, j] = pageList[i - 1, j];
                }
                if (f)         //pageList is full
                {
                    sumInterrupt++;
                    isInterrupt[i] = true;
                    if (location != -1)
                    {
                        pageList[i, location] = pages[i];
                    }
                    else
                    {
                        outPage[i] = pageList[i, 0];
                        for (j = 0; j < pageSize - 1; j++)
                            pageList[i, j] = pageList[i, j + 1];
                        pageList[i, pageSize - 1] = pages[i];
                    }
                }
                else
                {
                    outPage[i] = -1;
                    isInterrupt[i] = false;
                }
            }
            percent = (double)sumInterrupt / (double)pageLength;
        }

        public void pageReplacementLRU()
        {
            sumInterrupt = 0;
            int i, j, k;
            int location;
            int tmp;
            int f;
            outPage[0] = -1;
            isInterrupt[0] = false;
            for (i = 0; i < pageSize; i++)
            {
                pageList[0, i] = -1;
                outPage[i] = -1;
            }
            pageList[0, 0] = pages[0];
            sumInterrupt++;
            isInterrupt[0] = true;
            for (i = 1; i < pages.Length; i++)
            {
                f = -1;
                location = -1;
                for (j = 0; j < pageSize; j++)
                {
                    if (pageList[i - 1, j] == pages[i]) f = j;
                    if (location == -1 && pageList[i - 1, j] == -1) location = j;
                    pageList[i, j] = pageList[i - 1, j];
                }
                if (f == -1)         //pageList is full
                {
                    sumInterrupt++;
                    isInterrupt[i] = true;
                    if (location != -1)
                    {
                        pageList[i, location] = pages[i];
                    }
                    else
                    {
                        outPage[i] = pageList[i, 0];
                        for (j = 0; j < pageSize - 1; j++)
                            pageList[i, j] = pageList[i, j + 1];
                        pageList[i, pageSize - 1] = pages[i];
                    }
                }
                else
                {
                    outPage[i] = -1;
                    isInterrupt[i] = false;
                    if (location == -1) location = pageSize - 1;
                    tmp = pageList[i, f];
                    for (j = f; j < location; j++)
                        pageList[i, j] = pageList[i, j + 1];
                    pageList[i, location] = tmp;
                }
            }
            percent = (double)sumInterrupt / (double)pageLength;
        }

    }
}
