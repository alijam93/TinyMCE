﻿using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TinyMCE.Editor.Statics;

namespace TinyMCE.Editor
{
    public partial class QuillTextEditor
    {
        [Parameter] public RenderFragment EditorContent { get; set; }

        [Parameter] public RenderFragment ToolbarContent { get; set; }

        [Parameter] public bool ReadOnly { get; set; } = false;

        [Parameter] public string Placeholder { get; set; } = "Compose an epic...";

        [Parameter] public string Theme { get; set; } = ThemeType.Snow;

        [Parameter] public string DebugLevel { get; set; } = DebugType.Info;

        private ElementReference QuillElement;
        private ElementReference ToolBar;

        protected override async Task
            OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Interop.CreateQuill(
                    JSRuntime,
                    QuillElement,
                    ToolBar,
                    ReadOnly,
                    Placeholder,
                    Theme,
                    DebugLevel);
            }
        }

        public async Task<string> GetText()
        {
            return await Interop.GetText(
                JSRuntime, QuillElement);
        }

        public async Task<string> GetHTML()
        {
            return await Interop.GetHTML(
                JSRuntime, QuillElement);
        }

        public async Task<string> GetContent()
        {
            return await Interop.GetContent(
                JSRuntime, QuillElement);
        }

        public async Task LoadContent(string Content)
        {
            var QuillDelta =
                await Interop.LoadQuillContent(
                    JSRuntime, QuillElement, Content);
        }

        public async Task LoadHTMLContent(string quillHTMLContent)
        {
            var QuillDelta =
                await Interop.LoadQuillHTMLContent(
                    JSRuntime, QuillElement, quillHTMLContent);
        }

        public async Task InsertImage(string ImageURL)
        {
            var QuillDelta =
                await Interop.InsertQuillImage(
                    JSRuntime, QuillElement, ImageURL);
        }

        public async Task EnableEditor(bool mode)
        {
            var QuillDelta =
                await Interop.EnableQuillEditor(
                    JSRuntime, QuillElement, mode);
        }
    }
}
