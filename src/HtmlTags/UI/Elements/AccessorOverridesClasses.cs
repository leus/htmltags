﻿using System;
using HtmlTags.Conventions;

namespace HtmlTags.UI.Elements
{
    public class AccessorOverrideBuilderPolicy : IElementBuilderPolicy
    {
        public bool Matches(ElementRequest subject)
        {
            var overrides = subject.Get<HtmlTags.Reflection.AccessorRules>();


            throw new NotImplementedException();
        }

        public ITagBuilder<ElementRequest> BuilderFor(ElementRequest subject)
        {
            throw new System.NotImplementedException();
        }
    }
}