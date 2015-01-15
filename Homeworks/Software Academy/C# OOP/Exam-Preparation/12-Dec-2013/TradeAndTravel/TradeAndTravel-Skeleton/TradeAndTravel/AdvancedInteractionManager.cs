using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class AdvancedInteractionManager : InteractionManager
    {
        //Override the input command handler. Extend it to support "gather" and "craft" commands.
        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            //The same switch operator with the new options and default case - base.HandlePersonCommand()
            switch (commandWords[1])
            { 
                //case "drop":
                //    HandleAdvancedDropInteraction(actor);
                //    break;
                case "gather":
                    HandleGatherInteraction(commandWords, actor);
                    break;
                case "craft":
                    HandleCraftInteraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        //private void HandleAdvancedDropInteraction(Person actor)
        //{
        //    foreach (var item in actor.ListInventory())
        //    {
        //        if (ownerByItem[item] == actor)
        //        {
        //            strayItemsByLocation[actor.Location].Add(item);
        //            this.RemoveFromPerson(actor, item);

        //            item.UpdateWithInteraction("drop");
        //        }
        //    }
        //}

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            if (actor.ListInventory().Exists(i => i.ItemType == ItemType.Iron))
            {
                if (commandWords[2] == "weapon")
                {
                    if (actor.ListInventory().Exists(i => i.ItemType == ItemType.Wood))
                    {
                        AddToPerson(actor, new Weapon(commandWords[3], actor.Location));
                    }
                }
                else if (commandWords[2] == "armor")
                {
                    AddToPerson(actor, new Armor(commandWords[3], actor.Location));
                }
            }
        }

        private void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            if (actor.Location.LocationType == LocationType.Forest)
            {
                if (actor.ListInventory().Exists(i => i.ItemType == ItemType.Weapon))
                {
                    AddToPerson(actor, new Wood(commandWords[2], actor.Location));
                    //actor.AddToInventory(new Wood(commandWords[2], actor.Location));
                }
            }
            else if (actor.Location.LocationType == LocationType.Mine)
            {
                if (actor.ListInventory().Exists(i => i.ItemType == ItemType.Armor))
                {
                    AddToPerson(actor, new Iron(commandWords[2], actor.Location));
                    //actor.AddToInventory(new Iron(commandWords[2], actor.Location));
                }
            }
        }

        //Override creation commands. 

        //Override CreateItem to support creation for the weapon, wood and iron
        protected override Item CreateItem(string itemTypeString,
            string itemNameString, Location itemLocation, Item item)
        {
            //The same switch operator with the new options and default case - base.CreateItem()
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }

            return item;
        }

        //Override CreateLocation to support creation for the mine and the forest
        protected override Location CreateLocation(string locationTypeString,
            string locationName)
        {
            //The same switch operator with the new options and default case - base.CreateLocation()
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }

            return location;
        }
        
        //Override CreatePerson to support creation for the merchant
        protected override Person CreatePerson(string personTypeString,
            string personNameString, Location personLocation)
        {
            //The same switch operator with the new options and default case - base.CreatePerson()
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }

            return person;
        }
    }
}