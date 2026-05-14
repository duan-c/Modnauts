NAME = "Modnauts"
VERSION_NUM=11

function SteamDetails()
    local desc = "Modnauts v1.0 Demo\r\n" ..
		"\r\n" ..
		"⚙Folk Bot Brain Upgrade\r\n" ..
		"⚙Hoverboard \r\n" ..
		"⚙Rubber Chicken \r\n" ..
		"⚙Ranging Rod \r\n" ..
		"\r\n" ..
		"Plugin required: [url=https://github.com/duan-c/Modnauts]Modnauts[/url]"
    ModBase.SetSteamWorkshopDetails(NAME, desc, {"mod", "demo", "player", "bot", "upgrade", "inventory", "movement", "whistle", "carry", "energy", "memory", "search", "sign"}, "Modnauts.png")
end

function Creation()
	if ModUpgrade == nil then
		return;
	end
	-- FolkBrain
	ModUpgrade.CreateUpgradeWorkerMemory(
		"UpgradeWorkerMemoryFolk",
		96,
		{ "Piston", "FolkSeed" },
		{ 1, 1 },
		"FolkBrain",
		true
		)
    ModText.SetText("UpgradeWorkerMemoryFolk", "Folk Bot Brain Upgrade")
    ModText.SetDescription("UpgradeWorkerMemoryFolk", "They are useful after all")
	-- Hoverboard
	ModUpgrade.CreateUpgradePlayerMovement(
		"UpgradePlayerMovementHoverboard",
		0.25,
		{ "MetalPlateCrude", "Butter", "PaintRed" },
		{ 1, 8, 1 },
		"Hoverboard",
		true
		)
    ModText.SetText("UpgradePlayerMovementHoverboard", "Hoverboard")
    ModText.SetDescription("UpgradePlayerMovementHoverboard", "")
	-- RubberChicken
	ModUpgrade.CreateUpgradePlayerWhistle(
		"UpgradePlayerWhistleRubberChicken",
		"WhistleCallRubberChicken",
		"WhistleCancelRubberChicken",
		"WhistleDropAllRubberChicken",
		"WhistleToMeRubberChicken",
		{ "AnimalChicken", "Honey" },
		{ 1, 1 },
		"RubberChicken",
		true
		)
    ModText.SetText("UpgradePlayerWhistleRubberChicken", "Rubber Chicken")
    ModText.SetDescription("UpgradePlayerWhistleRubberChicken", "")
	-- RangingRod
	ModUpgrade.CreateSign(
		"RangingRod",
		25,
		{ "Pole", "PaintRed" },
		{ 1, 1 },
		"RangingRod",
		true
		)
    ModText.SetText("RangingRod", "Ranging Rod")
    ModText.SetDescription("RangingRod", "Control Bot search areas. Press %kUseInHand while holding the sign to edit it.")
end

function BeforeLoad()
	if ModUpgrade == nil then
		return;
	end
	-- set upgrade levels
	ModUpgrade.SetUpgradeLevel("UpgradeWorkerMemoryFolk", 3)
	ModUpgrade.SetUpgradeLevel("UpgradePlayerMovementHoverboard", 3)
	-- assign converters
	ModVariable.AddRecipeToConverter("WorkerWorkbenchMk3", "UpgradeWorkerMemoryFolk")
	ModVariable.AddRecipeToConverter("WorkbenchMk2", "UpgradePlayerMovementHoverboard")
	ModVariable.AddRecipeToConverter("ButterChurn", "UpgradePlayerWhistleRubberChicken")
	ModVariable.AddRecipeToConverter("WorkbenchMk2", "RangingRod")
	-- register custom sound files with the custom sound events
	ModSound.ChangeSound("WhistleCallRubberChicken", "WhistleCallRubberChicken")
	ModSound.ChangeSound("WhistleCancelRubberChicken", "WhistleCancelRubberChicken")
	ModSound.ChangeSound("WhistleDropAllRubberChicken", "WhistleDropAllRubberChicken")
	ModSound.ChangeSound("WhistleToMeRubberChicken", "WhistleToMeRubberChicken")
end

local modnauts_checked = false
function OnUpdate()
	if not modnauts_checked then
		modnauts_checked = true
		if ModUpgrade == nil then
			ModUI.ShowPopup("Modnauts plugin not loaded", "The Modnauts demo mod will not work as intended!")
		end
	end
end
