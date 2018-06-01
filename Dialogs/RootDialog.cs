using LuisBot.Components;
using LuisBot.DTOs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Sample.LuisBot;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace LuisBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            var qnaResponse = await QNAComponent.MakeQNARequest(message.Text);
            var luisResponse = await LuisComponent.MakeLuisRequest(message.Text);

            var qna = JsonConvert.DeserializeObject<QnaResponse>(qnaResponse);
            var luis = JsonConvert.DeserializeObject<LuisResponse>(luisResponse);

            if (luis.topScoringIntent.score > 0.7 && luis.topScoringIntent.intent != "None")
            {
                //send to top level Luis Intent handler. 
                //There is a potential optimisation here as Luis is being called twice (once here and again in the BasicLuisDialog). Need to see if there is a way to us ethe Built-in LuisIntent object but pass a Luis response to it rather than a message
                await context.Forward(new BasicLuisDialog(), ResumeAfterSubDialog, message, CancellationToken.None);
            }
            else if (qna.answers.First().answer != "No good match found in KB.")
            {
                //show QnA answer
                await context.PostAsync($"QnA Maker provided this repsonse: {qna.answers.First().answer}");
                context.Wait(this.MessageReceivedAsync);
            }
            else
            {
                await context.PostAsync("Sorry I didn't understand that");
                context.Wait(this.MessageReceivedAsync);
            }
        }

        private async Task ResumeAfterSubDialog(IDialogContext context, IAwaitable<object> result)
        {
            context.Done("");
        }
    }
}