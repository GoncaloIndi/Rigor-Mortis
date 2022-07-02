// GENERATED AUTOMATICALLY FROM 'Assets/InputActions/PlayerInputManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputManager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputManager"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""d41b18b1-fc6f-446e-b06f-65bb07ae325b"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""13f6d9e9-d3cc-4f44-8410-b3634b7c7a2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""8522f734-0cc4-40a5-b50c-822993318fc6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""6859bdab-3e6c-4d79-ae47-2225e437ab20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""QuickTurn"",
                    ""type"": ""Button"",
                    ""id"": ""9491a865-9df8-4a0f-b345-31847c9cd2e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttackLockOn"",
                    ""type"": ""Button"",
                    ""id"": ""dfdbc168-70d2-401c-ace2-84aae37b5080"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""eead7712-29e0-4292-b7b4-77666ed0ac57"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""bc584482-7dde-4163-bd16-604a66d130dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""489cc68f-067a-4d86-b03e-28cb752b90f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d50dd434-c76d-44c4-9c19-d8ea6b01abdc"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ec4ef6c-be00-42b1-b450-155ecf974221"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""199dc97a-7ad9-4a3a-b370-6becffeee76d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cf812b9f-00f9-49eb-97f7-789ce42ba2ec"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""969d36ec-cb00-48d9-afe6-88051279f48b"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1e350d57-f255-42a4-ba92-d8539592f1f0"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""af3f7abf-2142-4cd2-a0ef-50f24c23126b"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c9a1feca-5f8b-4977-988b-6accc4ca14cf"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""37871152-be9e-4487-9110-597690f6f89b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1b754615-6865-463c-8afe-ffab40fd3bd9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6e63319f-5fb2-4149-8410-86097a2be210"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7122dd0b-9806-4b1e-9198-2651e0179f11"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""38d4813f-522d-46b0-87a5-07b80a7c5d85"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""405d331f-0696-4e20-80c7-d4dd21009c57"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""22d50e20-4e14-4a66-a220-7309568b1f7b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e0267f7b-282b-432e-94b7-4e377308a3bd"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""664a946a-81a8-4f4b-bb8f-36a5113836dd"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""99b815ac-0c45-4e31-9113-7dc26214b0c3"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4971fd86-e5bb-458e-83fc-e76c0980575c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e098ed59-84c1-417e-a9e9-8b3abb97e214"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""QuickTurn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f906bf29-582d-4634-aa10-b8545d2aaff8"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""QuickTurn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9444c30-741f-4db2-93dd-1cb0516030c1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""AttackLockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07cf6ec8-7bfc-480f-85e5-ae5cf825fcbc"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AttackLockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13175c80-8eed-4985-8188-f74542319b64"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc3544ce-6806-4da1-aa2c-40780fb1b791"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e36337b-0716-449c-a400-1bfda70b322a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c0cf1ef-dc50-4261-b53a-9d1f4d8e6bbc"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88c96839-342d-4610-a433-ec017523bb0c"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18db11a0-cc43-468e-9480-e2e97a284918"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8418a54a-7adc-40ac-9eeb-5a521e2b31d0"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InteractionUI"",
            ""id"": ""d10a9c58-56bc-4354-b0ed-900c5530ceb1"",
            ""actions"": [
                {
                    ""name"": ""Accept"",
                    ""type"": ""Button"",
                    ""id"": ""0a14a626-4cc5-4541-855d-3c8da414b71c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d7e0fe33-0ee2-4776-89f3-13086e7947f4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""722739cf-25e3-476e-9e66-4144c820528e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df08a956-5217-4157-8fef-8758a57f0ac6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""NoInput"",
            ""id"": ""70acf9fa-1952-4703-bef0-4d29867ca293"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""cb924041-679f-4c17-b34c-e45c4bf501bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""60044be1-0ae0-4450-b304-fe2352fbee83"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2aa55df4-de1b-40b8-979b-a42b1191a4ef"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PauseMenuUI"",
            ""id"": ""05bd6e49-ddb7-4d41-807f-41ceb3cead4b"",
            ""actions"": [
                {
                    ""name"": ""Resume"",
                    ""type"": ""Button"",
                    ""id"": ""ca5cbd6b-82bd-4ebf-a002-8d7d79fdbd5f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""6ef732ad-fd0a-4c65-9e12-e61e205ce2ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""b3b59d03-4a48-4c39-83ae-88e6254bd839"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""e0e0e5f3-5378-4fd1-9319-7630831450fc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7bcafb6b-2187-48e2-a54f-f9a5f2cccd87"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Resume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7dc436a6-9401-4cdc-ac46-ab0d4a990a63"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec6ad787-99f0-4216-88c6-da71337f4aa4"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95295460-9c30-4a8d-afca-523967797243"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c354e34c-b328-4db5-8582-cc284b538334"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""da404bff-e226-46a1-8655-d3f2040b54d1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""99ca158f-3424-4f6b-9ad8-a27565fba1bf"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f9f78b63-5193-48bc-9575-f41d00dcc2ce"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cb1577a3-acd0-4c09-bc38-186a7241c36f"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9bbe2e7d-b18d-401b-9552-918eaf4cdb2d"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c80fb53b-29d3-46e3-9600-c41fa1def7ce"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4fccacdb-0f90-41b6-a0c3-21a38b51deac"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b29be809-a80a-4601-a49a-a59ac9a48ad9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c0bf64b2-20eb-43ef-8b96-96fb1334cd74"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""874e77a0-7ded-4297-a6dc-c4b64b24df1c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f23860b8-e9ce-47d8-ba2b-6d09683ddd9d"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8971bb65-896a-4554-af3b-f9b34f88753a"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c448a268-dd37-4848-91c9-65c306a7149f"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""22d836f2-517a-4238-bfc5-13863e688bbc"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""10fe6813-84be-416a-a349-985e1a6b5064"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Inventory"",
            ""id"": ""6c9271aa-de55-40f2-96af-ce8bcae59fd0"",
            ""actions"": [
                {
                    ""name"": ""Resume"",
                    ""type"": ""Button"",
                    ""id"": ""7b7d0aad-972d-4d31-91f1-00e452c07fc5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""b27c71db-d42e-488b-a99c-c93c2991d4f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextTab"",
                    ""type"": ""Button"",
                    ""id"": ""6e69e2aa-b68f-457e-bffa-4f4512ed939c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PreviousTab"",
                    ""type"": ""Button"",
                    ""id"": ""d2d3bc2b-0e48-4eda-a7ae-901564d63147"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextItem"",
                    ""type"": ""Button"",
                    ""id"": ""ee63f3f7-e59f-47d3-b3f4-224f739a672b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PreviousItem"",
                    ""type"": ""Button"",
                    ""id"": ""b68a3bd6-9040-4139-ae36-9d1c7409a6a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""82c8c55c-68ed-4066-8ffd-93b874588a9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2f2a6ac1-aaf1-440b-b4bd-9b90d7547b09"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Resume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ddb384b-d20b-4415-b348-a8816e2e5fc3"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Resume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f876d39e-b8ca-464c-8fd8-f49e3df06179"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Resume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08e1cf09-dd41-41e3-af7a-2267c497c51a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17d02e82-7b54-43c9-8b5c-c8759b3e1fbd"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c37ec53-5114-4aea-a255-be359cdf6f1a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""NextTab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""063b62e5-553e-44c6-bc1d-b0fd06a8ce82"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""NextTab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32984f32-170e-45f2-8cd3-fe754bcf2a85"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PreviousTab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37f5b68c-0c55-4352-90bc-d4e84f7b9400"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""PreviousTab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2522c2a1-10eb-40ed-b94c-02b3ef6be8c4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""NextItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00917d9e-12e0-4b8f-aa2a-0b2a3603b1f7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""NextItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e033ade-f9d5-431e-89b1-4feb1bd0d129"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""NextItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c17de9a8-0e76-464e-abaa-2babb33ce44f"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""NextItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9d45f5a-ccbf-44df-8c6d-00b83c9be771"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""PreviousItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6705edc0-b800-4f2a-9e14-afd6556ddee1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""PreviousItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f6284a6-bc6c-4447-ad88-e0e547aa04e4"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PreviousItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b75e19ce-356f-4c8b-b232-ec5129cff3b0"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PreviousItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f9bac69-6f25-4f0a-9066-e76395c7320e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7406f3a-8390-4c66-a0da-c351630dbdfd"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a503c12-9781-4649-aa1f-ad79fc9dc16d"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8d3e93e-cee4-4575-8d39-1b8ea599fa72"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and mouse"",
            ""bindingGroup"": ""Keyboard and mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
        m_Player_QuickTurn = m_Player.FindAction("QuickTurn", throwIfNotFound: true);
        m_Player_AttackLockOn = m_Player.FindAction("AttackLockOn", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_Inventory = m_Player.FindAction("Inventory", throwIfNotFound: true);
        // InteractionUI
        m_InteractionUI = asset.FindActionMap("InteractionUI", throwIfNotFound: true);
        m_InteractionUI_Accept = m_InteractionUI.FindAction("Accept", throwIfNotFound: true);
        // NoInput
        m_NoInput = asset.FindActionMap("NoInput", throwIfNotFound: true);
        m_NoInput_Pause = m_NoInput.FindAction("Pause", throwIfNotFound: true);
        // PauseMenuUI
        m_PauseMenuUI = asset.FindActionMap("PauseMenuUI", throwIfNotFound: true);
        m_PauseMenuUI_Resume = m_PauseMenuUI.FindAction("Resume", throwIfNotFound: true);
        m_PauseMenuUI_Back = m_PauseMenuUI.FindAction("Back", throwIfNotFound: true);
        m_PauseMenuUI_Confirm = m_PauseMenuUI.FindAction("Confirm", throwIfNotFound: true);
        m_PauseMenuUI_Navigate = m_PauseMenuUI.FindAction("Navigate", throwIfNotFound: true);
        // Inventory
        m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
        m_Inventory_Resume = m_Inventory.FindAction("Resume", throwIfNotFound: true);
        m_Inventory_Back = m_Inventory.FindAction("Back", throwIfNotFound: true);
        m_Inventory_NextTab = m_Inventory.FindAction("NextTab", throwIfNotFound: true);
        m_Inventory_PreviousTab = m_Inventory.FindAction("PreviousTab", throwIfNotFound: true);
        m_Inventory_NextItem = m_Inventory.FindAction("NextItem", throwIfNotFound: true);
        m_Inventory_PreviousItem = m_Inventory.FindAction("PreviousItem", throwIfNotFound: true);
        m_Inventory_Use = m_Inventory.FindAction("Use", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Sprint;
    private readonly InputAction m_Player_QuickTurn;
    private readonly InputAction m_Player_AttackLockOn;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_Inventory;
    public struct PlayerActions
    {
        private @PlayerInputManager m_Wrapper;
        public PlayerActions(@PlayerInputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Sprint => m_Wrapper.m_Player_Sprint;
        public InputAction @QuickTurn => m_Wrapper.m_Player_QuickTurn;
        public InputAction @AttackLockOn => m_Wrapper.m_Player_AttackLockOn;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @Inventory => m_Wrapper.m_Player_Inventory;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Sprint.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @QuickTurn.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuickTurn;
                @QuickTurn.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuickTurn;
                @QuickTurn.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuickTurn;
                @AttackLockOn.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackLockOn;
                @AttackLockOn.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackLockOn;
                @AttackLockOn.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackLockOn;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Inventory.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @QuickTurn.started += instance.OnQuickTurn;
                @QuickTurn.performed += instance.OnQuickTurn;
                @QuickTurn.canceled += instance.OnQuickTurn;
                @AttackLockOn.started += instance.OnAttackLockOn;
                @AttackLockOn.performed += instance.OnAttackLockOn;
                @AttackLockOn.canceled += instance.OnAttackLockOn;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // InteractionUI
    private readonly InputActionMap m_InteractionUI;
    private IInteractionUIActions m_InteractionUIActionsCallbackInterface;
    private readonly InputAction m_InteractionUI_Accept;
    public struct InteractionUIActions
    {
        private @PlayerInputManager m_Wrapper;
        public InteractionUIActions(@PlayerInputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accept => m_Wrapper.m_InteractionUI_Accept;
        public InputActionMap Get() { return m_Wrapper.m_InteractionUI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractionUIActions set) { return set.Get(); }
        public void SetCallbacks(IInteractionUIActions instance)
        {
            if (m_Wrapper.m_InteractionUIActionsCallbackInterface != null)
            {
                @Accept.started -= m_Wrapper.m_InteractionUIActionsCallbackInterface.OnAccept;
                @Accept.performed -= m_Wrapper.m_InteractionUIActionsCallbackInterface.OnAccept;
                @Accept.canceled -= m_Wrapper.m_InteractionUIActionsCallbackInterface.OnAccept;
            }
            m_Wrapper.m_InteractionUIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Accept.started += instance.OnAccept;
                @Accept.performed += instance.OnAccept;
                @Accept.canceled += instance.OnAccept;
            }
        }
    }
    public InteractionUIActions @InteractionUI => new InteractionUIActions(this);

    // NoInput
    private readonly InputActionMap m_NoInput;
    private INoInputActions m_NoInputActionsCallbackInterface;
    private readonly InputAction m_NoInput_Pause;
    public struct NoInputActions
    {
        private @PlayerInputManager m_Wrapper;
        public NoInputActions(@PlayerInputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_NoInput_Pause;
        public InputActionMap Get() { return m_Wrapper.m_NoInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NoInputActions set) { return set.Get(); }
        public void SetCallbacks(INoInputActions instance)
        {
            if (m_Wrapper.m_NoInputActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_NoInputActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_NoInputActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_NoInputActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_NoInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public NoInputActions @NoInput => new NoInputActions(this);

    // PauseMenuUI
    private readonly InputActionMap m_PauseMenuUI;
    private IPauseMenuUIActions m_PauseMenuUIActionsCallbackInterface;
    private readonly InputAction m_PauseMenuUI_Resume;
    private readonly InputAction m_PauseMenuUI_Back;
    private readonly InputAction m_PauseMenuUI_Confirm;
    private readonly InputAction m_PauseMenuUI_Navigate;
    public struct PauseMenuUIActions
    {
        private @PlayerInputManager m_Wrapper;
        public PauseMenuUIActions(@PlayerInputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Resume => m_Wrapper.m_PauseMenuUI_Resume;
        public InputAction @Back => m_Wrapper.m_PauseMenuUI_Back;
        public InputAction @Confirm => m_Wrapper.m_PauseMenuUI_Confirm;
        public InputAction @Navigate => m_Wrapper.m_PauseMenuUI_Navigate;
        public InputActionMap Get() { return m_Wrapper.m_PauseMenuUI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseMenuUIActions set) { return set.Get(); }
        public void SetCallbacks(IPauseMenuUIActions instance)
        {
            if (m_Wrapper.m_PauseMenuUIActionsCallbackInterface != null)
            {
                @Resume.started -= m_Wrapper.m_PauseMenuUIActionsCallbackInterface.OnResume;
                @Resume.performed -= m_Wrapper.m_PauseMenuUIActionsCallbackInterface.OnResume;
                @Resume.canceled -= m_Wrapper.m_PauseMenuUIActionsCallbackInterface.OnResume;
                @Back.started -= m_Wrapper.m_PauseMenuUIActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_PauseMenuUIActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_PauseMenuUIActionsCallbackInterface.OnBack;
                @Confirm.started -= m_Wrapper.m_PauseMenuUIActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_PauseMenuUIActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_PauseMenuUIActionsCallbackInterface.OnConfirm;
                @Navigate.started -= m_Wrapper.m_PauseMenuUIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_PauseMenuUIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_PauseMenuUIActionsCallbackInterface.OnNavigate;
            }
            m_Wrapper.m_PauseMenuUIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Resume.started += instance.OnResume;
                @Resume.performed += instance.OnResume;
                @Resume.canceled += instance.OnResume;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
            }
        }
    }
    public PauseMenuUIActions @PauseMenuUI => new PauseMenuUIActions(this);

    // Inventory
    private readonly InputActionMap m_Inventory;
    private IInventoryActions m_InventoryActionsCallbackInterface;
    private readonly InputAction m_Inventory_Resume;
    private readonly InputAction m_Inventory_Back;
    private readonly InputAction m_Inventory_NextTab;
    private readonly InputAction m_Inventory_PreviousTab;
    private readonly InputAction m_Inventory_NextItem;
    private readonly InputAction m_Inventory_PreviousItem;
    private readonly InputAction m_Inventory_Use;
    public struct InventoryActions
    {
        private @PlayerInputManager m_Wrapper;
        public InventoryActions(@PlayerInputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Resume => m_Wrapper.m_Inventory_Resume;
        public InputAction @Back => m_Wrapper.m_Inventory_Back;
        public InputAction @NextTab => m_Wrapper.m_Inventory_NextTab;
        public InputAction @PreviousTab => m_Wrapper.m_Inventory_PreviousTab;
        public InputAction @NextItem => m_Wrapper.m_Inventory_NextItem;
        public InputAction @PreviousItem => m_Wrapper.m_Inventory_PreviousItem;
        public InputAction @Use => m_Wrapper.m_Inventory_Use;
        public InputActionMap Get() { return m_Wrapper.m_Inventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
        public void SetCallbacks(IInventoryActions instance)
        {
            if (m_Wrapper.m_InventoryActionsCallbackInterface != null)
            {
                @Resume.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnResume;
                @Resume.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnResume;
                @Resume.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnResume;
                @Back.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnBack;
                @NextTab.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnNextTab;
                @NextTab.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnNextTab;
                @NextTab.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnNextTab;
                @PreviousTab.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnPreviousTab;
                @PreviousTab.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnPreviousTab;
                @PreviousTab.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnPreviousTab;
                @NextItem.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnNextItem;
                @NextItem.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnNextItem;
                @NextItem.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnNextItem;
                @PreviousItem.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnPreviousItem;
                @PreviousItem.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnPreviousItem;
                @PreviousItem.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnPreviousItem;
                @Use.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnUse;
            }
            m_Wrapper.m_InventoryActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Resume.started += instance.OnResume;
                @Resume.performed += instance.OnResume;
                @Resume.canceled += instance.OnResume;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @NextTab.started += instance.OnNextTab;
                @NextTab.performed += instance.OnNextTab;
                @NextTab.canceled += instance.OnNextTab;
                @PreviousTab.started += instance.OnPreviousTab;
                @PreviousTab.performed += instance.OnPreviousTab;
                @PreviousTab.canceled += instance.OnPreviousTab;
                @NextItem.started += instance.OnNextItem;
                @NextItem.performed += instance.OnNextItem;
                @NextItem.canceled += instance.OnNextItem;
                @PreviousItem.started += instance.OnPreviousItem;
                @PreviousItem.performed += instance.OnPreviousItem;
                @PreviousItem.canceled += instance.OnPreviousItem;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
            }
        }
    }
    public InventoryActions @Inventory => new InventoryActions(this);
    private int m_KeyboardandmouseSchemeIndex = -1;
    public InputControlScheme KeyboardandmouseScheme
    {
        get
        {
            if (m_KeyboardandmouseSchemeIndex == -1) m_KeyboardandmouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and mouse");
            return asset.controlSchemes[m_KeyboardandmouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnQuickTurn(InputAction.CallbackContext context);
        void OnAttackLockOn(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
    }
    public interface IInteractionUIActions
    {
        void OnAccept(InputAction.CallbackContext context);
    }
    public interface INoInputActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IPauseMenuUIActions
    {
        void OnResume(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
        void OnNavigate(InputAction.CallbackContext context);
    }
    public interface IInventoryActions
    {
        void OnResume(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnNextTab(InputAction.CallbackContext context);
        void OnPreviousTab(InputAction.CallbackContext context);
        void OnNextItem(InputAction.CallbackContext context);
        void OnPreviousItem(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
    }
}
