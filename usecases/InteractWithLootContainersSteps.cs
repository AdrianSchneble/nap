using System;
using TechTalk.SpecFlow;

namespace NAP
{
    [Binding]
    public class InteractWithLootContainersSteps
    {
        [Given(@"I am standing on a GroundTile adjacent to the loot container")]
        public void GivenIAmStandingOnAGroundTileAdjacentToTheLootContainer()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the loot container is not a mimic")]
        public void GivenTheLootContainerIsNotAMimic()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the loot container is a mimic")]
        public void GivenTheLootContainerIsAMimic()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the mimic dies")]
        public void WhenTheMimicDies()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the loot container should open")]
        public void ThenTheLootContainerShouldOpen()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the contained items should be added to my inventory")]
        public void ThenTheContainedItemsShouldBeAddedToMyInventory()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the items dropped by the mimic should be added to my inventory")]
        public void ThenTheItemsDroppedByTheMimicShouldBeAddedToMyInventory()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
