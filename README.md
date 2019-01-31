# This content is out of date. Please look to use the [Dispatcher](https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-tutorial-dispatch?view=azure-bot-service-4.0&tabs=csharp) to triage between Luis and QNA

# Bot Luis QnA Triage
It is very common for bots to need [QnA Maker](https://www.qnamaker.ai/) as well as [Luis](https://azure.microsoft.com/en-us/services/cognitive-services/language-understanding-intelligent-service/) to support both natural language and more specific FAQs.

An example might be a customer service bot that uses QnA Maker to answer general enquiries where everyone gets the same answer (i.e. opening hours, telephone number etc) and Luis to handle more specific account based enquiries (i.e. "i want to change my password").

This sample triages messages from the user between Luis and QnA maker and show the appropriate response based on the confidence score. In this example, the assumption is made that if Luis returns 70% confidence or higher, then the Luis result is used, otherwise the QNA result is used.

Read more about the problem space and background for this sample at https://blogs.msdn.microsoft.com/martinkearn/2018/06/04/bot-framework-triage-between-luis-and-qna-maker/

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

## Credits
This sample derives from some work [Toby Bradshaw](https://github.com/tobybrad) and [Martin Kearn](https://github.com/martinkearn) did with a customer and was genericsed by Martin Kearn.
