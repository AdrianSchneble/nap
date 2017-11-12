using System;
using TechTalk.SpecFlow;

namespace NAP
{
    [Binding]
    public class OpenDoorSteps
    {
        [Given(@"I am standing on a GroundTile adjacent to the door")]
        public void GivenIAmStandingOnAGroundTileAdjacentToTheDoor()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the door is closed")]
        public void GivenTheDoorIsClosed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the door is unlocked")]
        public void GivenTheDoorIsUnlocked()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the door is locked")]
        public void GivenTheDoorIsLocked()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have a key")]
        public void GivenIHaveAKey()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I do not have a key")]
        public void GivenIDoNotHaveAKey()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the door is open")]
        public void GivenTheDoorIsOpen()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"no Entity is in the door")]
        public void GivenNoEntityIsInTheDoor()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press E")]
        public void WhenIPressE()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the door should open")]
        public void ThenTheDoorShouldOpen()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the key should be removed from my Inventory")]
        public void ThenTheKeyShouldBeRemovedFromMyInventory()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the door should not open")]
        public void ThenTheDoorShouldNotOpen()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the door should close")]
        public void ThenTheDoorShouldClose()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
