# Bot Luis QnA Triage
It is very common for bots to need QnA Maker as well as a bunch of several other services which are generally supported with natural language by Luis.

This sample helps triage message between Luis and QnA maker based on the confidence scores from those services.

Keys have been left in the source code deliberately so the solution and associated models can be used straight away. If you fork this repository, please use your own keys and models.

## Luis Configuration
This project started an an Azure Bot Service (C# with Language Understanding template) and so the Luis model was automatically created as part of this process.

The default Luis model supports several default intents such as 'Help', 'Cancel' etc. 

The following messages should be triaged and answered by Luis (various intents)
* "Cancel"
* "Help"
* "Hi"

## QnA Maker Configuration
The QnA maker service has been manually created and has been trained with the FAQs for the Cognitive Services QNA Maker service itself. You can see the FAQs here: https://azure.microsoft.com/en-us/services/cognitive-services/qna-maker/faq/

The following messages should be triaged and answered by QNA Maker:
* "Is the QnA Maker Service free?"
* "What is the roadmap of the QnA Maker?"
