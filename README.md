# Bot Luis QnA Triage
It is very common for bots to need QnA Maker as well as a bunch of several other services which are generally supported with natural language by Luis.

This sample helps triage message between Luis and QnA maker based on the confidence scores from those services.

This project started an an Azure Bot Service (C# with Language Understanding template) and so the Luis model supports all the default intents such as 'Help', 'Cancel' etc. The QnA maker sevice is trained with a small selection of Q&A pairings
