using System;
using System.Linq;
using Xunit;

namespace RunningContest.Test
{
    public class ProgramTest
    {

        [Fact]
        public void GenerateGeneralRanking_OneOrderedListWithOneElement_ReturnsListWithOneElement()
        {
            Contest contest = new Contest();
            ContestRanking[] series = new ContestRanking[1];
            Contestant[] contestants = new Contestant[1];
            contestants[0] = new Contestant("Tester", "Romania", 1);
            series[0].Contestants = contestants;
            contest.Series = series;
            Program.GenerateGeneralRanking(ref contest);
            Assert.Single(contest.GeneralRanking.Contestants);
        }

        [Fact]
        public void GenerateGeneralRanking_TwoListsWithOneElement_ReturnsCombinedList()
        {
            Contest contest = new Contest();
            ContestRanking[] series = new ContestRanking[2];
            Contestant[] contestants = new Contestant[1];
            contestants[0] = new Contestant("Tester", "Romania", 1);
            Contestant[] contestants2 = new Contestant[1];
            contestants2[0] = new Contestant("Tester2", "Ungaria", 2);
            series[0].Contestants = contestants;
            series[1].Contestants = contestants2;
            contest.Series = series;
            Program.GenerateGeneralRanking(ref contest);
            Assert.Equal(2 ,contest.GeneralRanking.Contestants.Length);
        }

        [Fact]
        public void GenerateGeneralRanking_TwoListsWithTwoUnorderedElements_FirstElementHasLowestTimeValue()
        {
            Contest contest = new Contest();
            ContestRanking[] series = new ContestRanking[2];
            Contestant[] contestants = new Contestant[2];
            contestants[0] = new Contestant("Tester", "Romania", 2.2);
            contestants[1] = new Contestant("Tester", "Romania", 2.1);
            Contestant[] contestants2 = new Contestant[2];
            contestants2[0] = new Contestant("Tester2", "Ungaria", 1.5);
            contestants2[1] = new Contestant("Tester2", "Ungaria", 1.3);
            series[0].Contestants = contestants;
            series[1].Contestants = contestants2;
            contest.Series = series;
            Program.GenerateGeneralRanking(ref contest);
            Assert.Equal(1.3, contest.GeneralRanking.Contestants[0].Time);
        }

        [Fact]
        public void GenerateGeneralRanking_TwoEmptyContestantLists_ReturnsEmptyGeneralRanking()
        {
            Contest contest = new Contest();
            ContestRanking[] series = new ContestRanking[2];
            Contestant[] contestants = Array.Empty<Contestant>();
            Contestant[] contestants2 = Array.Empty<Contestant>();
            series[0].Contestants = contestants;
            series[1].Contestants = contestants2;
            contest.Series = series;
            Program.GenerateGeneralRanking(ref contest);
            Assert.Empty(contest.GeneralRanking.Contestants);
        }

        [Fact]
        public void GenerateGeneralRanking_EmptySeries_ReturnsEmptyGeneralRanking()
        {
            Contest contest = new Contest();
            ContestRanking[] series = Array.Empty<ContestRanking>();
            contest.Series = series;
            Program.GenerateGeneralRanking(ref contest);
            Assert.Empty(contest.GeneralRanking.Contestants);
        }

        private bool CheckListOrdered(Contestant[] list)
        {
            bool sorted = true;
            for (int i = 1; i < list.Length; i++)
            {
                if (list[i].Time < list[i - 1].Time)
                {
                    sorted = false;
                }
            }
            return sorted;
        }

        [Fact]
        public void GenerateGeneralRanking_TwoUnorderedLists_FinalListIsSorted()
        {
            Contest contest = new Contest();
            ContestRanking[] series = new ContestRanking[2];
            Contestant[] contestants = new Contestant[4];
            contestants[0] = new Contestant("Tester", "Romania", 2.2);
            contestants[1] = new Contestant("Tester", "Romania", 1.4);
            contestants[2] = new Contestant("Tester", "Romania", 2.9);
            contestants[3] = new Contestant("Tester", "Romania", 2.2);
            Contestant[] contestants2 = new Contestant[2];
            contestants2[0] = new Contestant("Tester2", "Ungaria", 1.5);
            contestants2[1] = new Contestant("Tester2", "Ungaria", 1.3);
            series[0].Contestants = contestants;
            series[1].Contestants = contestants2;
            contest.Series = series;
            Program.GenerateGeneralRanking(ref contest);
            contest.GeneralRanking.Contestants.ToArray();
            Assert.True(CheckListOrdered(contest.GeneralRanking.Contestants));
        }
    }
}
