using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizManager.Web.Components
{
    public partial class ModalComponent
    {
        [Parameter]
        public RenderFragment Title { get; set; }

        [Parameter]
        public RenderFragment Body { get; set; }

        [Parameter]
        public RenderFragment Footer { get; set; }

        public string Display = "none";
        public string Class = "";
        public List<string> Errors { get; set; }

        public void SetErrors(List<string> errors)
        {
            Errors = errors;
        }
        public async Task OpenModal()
        {
            Display = "block;";
            await Task.Delay(100);
            Class = "show";
            StateHasChanged();
        }

        public async Task CloseModal()
        {
            Class = "";
            await Task.Delay(250);
            Display = "none;";
            StateHasChanged();
        }
    }
}
