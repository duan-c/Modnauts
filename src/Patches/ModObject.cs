using HarmonyLib;
using Modnauts;
using System;
using System.Collections.Generic;

public static class ModObjectExtensions
{
    extension(ModObject modObject)
    {
        //TODO: this was a fools errand, I could have used reflection.  but maybe we can still make use of the effort by changing this to return more info of specific object.
        public string GetState(int UID)
        {
            try
            {
                BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID, false);
                if (objectFromUniqueID != null)
                {
                    Building building = objectFromUniqueID.GetComponent<Building>();
                    if (building != null )
                    {
                        Converter converter = objectFromUniqueID.GetComponent<Converter>();
                        if (converter != null)
                        {
                            return converter.m_State.ToString();
                        }
                        LinkedSystemEngine linkedSystemEngine = objectFromUniqueID.GetComponent<LinkedSystemEngine>();
                        if (linkedSystemEngine != null)
                        {
                            var linkedSystemEngineState = Traverse.CreateWithType("LinkedSystemEngine").Type("State").GetValue<Type>();
                            var m_state = Traverse.Create(linkedSystemEngine).Field("m_State").GetValue();
                            return Enum.GetName(linkedSystemEngineState, m_state);
                        }
                        ResearchStation researchStation = objectFromUniqueID.GetComponent<ResearchStation>();
                        if (researchStation != null)
                        {
                            return researchStation.m_State.ToString();
                        }
                        Storage storage = objectFromUniqueID.GetComponent<Storage>();
                        if (storage != null )
                        {
                            StorageFertiliser storageFertiliser = objectFromUniqueID.GetComponent<StorageFertiliser>();
                            if (storageFertiliser != null)
                            {
                                var storageFertiliserState = Traverse.CreateWithType("StorageFertiliser").Type("State").GetValue<Type>();
                                var m_state = Traverse.Create(storageFertiliser).Field("m_State").GetValue();
                                return Enum.GetName(storageFertiliserState, m_state);
                            }
                        }
                        TrainRefuellingStation trainRefuellingStation = objectFromUniqueID.GetComponent<TrainRefuellingStation>();
                        if (trainRefuellingStation != null)
                        {
                            var trainRefuellingStationState = Traverse.CreateWithType("TrainRefuellingStation").Type("State").GetValue<Type>();
                            var m_state = Traverse.Create(trainRefuellingStation).Field("m_State").GetValue();
                            return Enum.GetName(trainRefuellingStationState, m_state);
                        }
                        Wonder wonder = objectFromUniqueID.GetComponent<Wonder>();
                        if (wonder != null)
                        {
                            Catapult catapult = objectFromUniqueID.GetComponent<Catapult>();
                            if (catapult != null)
                            {
                                var catapultState = Traverse.CreateWithType("Catapult").Type("State").GetValue<Type>();
                                var m_state = Traverse.Create(catapult).Field("m_State").GetValue();
                                return Enum.GetName(catapultState, m_state);
                            }
                            SpacePort spacePort = objectFromUniqueID.GetComponent<SpacePort>();
                            if (spacePort != null)
                            {
                                return spacePort.m_State.ToString();
                            }
                            StoneHeads stoneHeads = objectFromUniqueID.GetComponent<StoneHeads>();
                            if (stoneHeads != null)
                            {
                                var stoneHeadsState = Traverse.CreateWithType("StoneHeads").Type("State").GetValue<Type>();
                                var m_state = Traverse.Create(stoneHeads).Field("m_State").GetValue();
                                return Enum.GetName(stoneHeadsState, m_state);
                            }
                            Wardrobe wardrobe = objectFromUniqueID.GetComponent<Wardrobe>();
                            if (wardrobe != null)
                            {
                                var wardrobeState = Traverse.CreateWithType("Wardrobe").Type("State").GetValue<Type>();
                                var m_state = Traverse.Create(wardrobe).Field("m_State").GetValue();
                                return Enum.GetName(wardrobeState, m_state);
                            }
                        }
                    }
                    Flora flora = objectFromUniqueID.GetComponent<Flora>();
                    if (flora != null)
                    {
                        Bullrushes bullrushes = objectFromUniqueID.GetComponent<Bullrushes>();
                        if (bullrushes != null)
                        {
                            return bullrushes.m_State.ToString();
                        }
                        Bush bush = objectFromUniqueID.GetComponent<Bush>();
                        if (bush != null)
                        {
                            return bush.m_State.ToString();
                        }
                        Crop crop = objectFromUniqueID.GetComponent<Crop>();
                        if (crop != null)
                        {
                            var m_state = Traverse.Create(crop).Field("m_State").GetValue<Crop.State>();
                            return m_state.ToString();
                        }
                        CropPumpkin cropPumpkin = objectFromUniqueID.GetComponent<CropPumpkin>();
                        if (cropPumpkin != null)
                        {
                            var cropPumpkinState = Traverse.CreateWithType("CropPumpkin").Type("State").GetValue<Type>();
                            var m_state = Traverse.Create(cropPumpkin).Field("m_State").GetValue();
                            return Enum.GetName(cropPumpkinState, m_state);
                        }
                        FlowerWild flowerWild = objectFromUniqueID.GetComponent<FlowerWild>();
                        if (flowerWild != null)
                        {
                            return flowerWild.m_State.ToString();
                        }
                        Grass grass = objectFromUniqueID.GetComponent<Grass>();
                        if (grass != null)
                        {
                            var grassState = Traverse.CreateWithType("Grass").Type("State").GetValue<Type>();
                            var m_state = Traverse.Create(grass).Field("m_State").GetValue();
                            return Enum.GetName(grassState, m_state);
                        }
                        Log log = objectFromUniqueID.GetComponent<Log>();
                        if (log != null)
                        {
                            return log.m_State.ToString();
                        }
                        Mushroom mushroom = objectFromUniqueID.GetComponent<Mushroom>();
                        if (mushroom != null)
                        {
                            return mushroom.m_State.ToString();
                        }
                        MyTree myTree = objectFromUniqueID.GetComponent<MyTree>();
                        if (myTree != null)
                        {
                            return myTree.m_State.ToString();
                        }
                        TreeStump treeStump = objectFromUniqueID.GetComponent<TreeStump>();
                        if (treeStump != null)
                        {
                            var m_state = Traverse.Create(treeStump).Field("m_State").GetValue<TreeStump.State>();
                            return m_state.ToString();
                        }
                        Weed weed = objectFromUniqueID.GetComponent<Weed>();
                        if (weed != null)
                        {
                            var m_state = Traverse.Create(weed).Field("m_State").GetValue<Weed.State>();
                            return m_state.ToString();
                        }
                    }
                    Holdable holdable = objectFromUniqueID.GetComponent<Holdable>();
                    if (holdable != null)
                    {
                        AnimalLeech animalLeech = objectFromUniqueID.GetComponent<AnimalLeech>();
                        if (animalLeech != null)
                        {
                            var animalLeechState = Traverse.CreateWithType("AnimalLeech").Type("State").GetValue<Type>();
                            var m_state = Traverse.Create(animalLeech).Field("m_State").GetValue();
                            return Enum.GetName(animalLeechState, m_state);
                        }
                        AnimalSilkworm animalSilkworm = objectFromUniqueID.GetComponent<AnimalSilkworm>();
                        if (animalSilkworm != null)
                        {
                            return animalSilkworm.m_State.ToString();
                        }
                        Clothing clothing = objectFromUniqueID.GetComponent<Clothing>();
                        if (clothing != null)
                        {
                            return clothing.GetState().ToString();
                        }
                        DataStorageCrude dataStorageCrude = objectFromUniqueID.GetComponent<DataStorageCrude>();
                        if (dataStorageCrude != null)
                        {
                            dataStorageCrude.m_State.ToString();
                        }
                        Fish fish = objectFromUniqueID.GetComponent<Fish>();
                        if (fish != null)
                        {
                            var fishState = Traverse.CreateWithType("Fish").Type("State").GetValue<Type>();
                            var m_state = Traverse.Create(fish).Field("m_State").GetValue();
                            return Enum.GetName(fishState, m_state);
                        }
                        FishBait fishBait = objectFromUniqueID.GetComponent<FishBait>();
                        if (fishBait != null)
                        {
                            var fishBaitState = Traverse.CreateWithType("FishBait").Type("State").GetValue<Type>();
                            var m_state = Traverse.Create(fishBait).Field("m_State").GetValue();
                            return Enum.GetName(fishBaitState, m_state);
                        }
                        FlowerPot flowerPot = objectFromUniqueID.GetComponent<FlowerPot>();
                        if (flowerPot != null)
                        {
                            return flowerPot.m_State.ToString();
                        }
                        GoTo goTo = objectFromUniqueID.GetComponent<GoTo>();
                        if (goTo != null)
                        {
                            Animal animal = objectFromUniqueID.GetComponent<Animal>();
                            if (animal != null)
                            {
                                AnimalBee animalBee = objectFromUniqueID.GetComponent<AnimalBee>();
                                if (animalBee != null)
                                {
                                    return animalBee.m_State.ToString();
                                }
                                AnimalBird animalBird = objectFromUniqueID.GetComponent<AnimalBird>();
                                if (animalBird != null)
                                {
                                    return animalBird.m_State.ToString();
                                }
                                AnimalGrazer animalGrazer = objectFromUniqueID.GetComponent<AnimalGrazer>();
                                if (animalGrazer != null)
                                {
                                    return animalGrazer.m_State.ToString();
                                }
                                AnimalPetDog animalPetDog = objectFromUniqueID.GetComponent<AnimalPetDog>();
                                if (animalPetDog != null)
                                {
                                    var animalPetDogState = Traverse.CreateWithType("AnimalPetDog").Type("State").GetValue<Type>();
                                    var m_state = Traverse.Create(animalPetDog).Field("m_State").GetValue();
                                    return Enum.GetName(animalPetDogState, m_state);
                                }
                            }
                            Folk folk = objectFromUniqueID.GetComponent<Folk>();
                            if (folk != null)
                            {
                                folk.m_State.ToString();
                            }
                            GoToMod goToMod = objectFromUniqueID.GetComponent<GoToMod>();
                            if (goToMod != null)
                            {
                                goToMod.m_State.ToString();
                            }
                            TutorBot tutorBot = objectFromUniqueID.GetComponent<TutorBot>();
                            if (tutorBot != null)
                            {
                                tutorBot.m_State.ToString();
                            }
                            Vehicle vehicle = objectFromUniqueID.GetComponent<Vehicle>();
                            if (vehicle != null)
                            {
                                vehicle.m_State.ToString();
                            }
                            //Farmer
                            Worker worker = objectFromUniqueID.GetComponent<Worker>();
                            if (worker != null)
                            {
                                return ModManager.Instance.ModBotClass.GetState(UID);
                            }
                        }
                        Plank plank = objectFromUniqueID.GetComponent<Plank>();
                        if (plank != null)
                        {
                            return plank.m_State.ToString();
                        }
                        Pole pole = objectFromUniqueID.GetComponent<Pole>();
                        if (pole != null)
                        {
                            return pole.m_State.ToString();
                        }
                        Upgrade upgrade = objectFromUniqueID.GetComponent<Upgrade>();
                        if (upgrade != null)
                        {
                            Sign sign = objectFromUniqueID.GetComponent<Sign>();
                            if (sign != null)
                            {
                                sign.m_State.ToString();
                            }
                        }
                    }
                    SpacePortRocket spacePortRocket = objectFromUniqueID.GetComponent<SpacePortRocket>();
                    if (spacePortRocket != null)
                    {
                        return spacePortRocket.m_State.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ModManager.Instance.WriteModError("ModObject.GetState Error: " + ex.ToString());
            }
            return "";
        }
    }
}