﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nancy;
using Nancy.Responses;

namespace NancyStartingPoint
{
    public class StaticContentBootstrapper : DefaultNancyBootstrapper
    {
        private readonly string _baseUrl;

        public StaticContentBootstrapper(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        #region Implementation of INancyBootstrapper

        protected override void InitialiseInternal(TinyIoC.TinyIoCContainer container)
        {
            base.InitialiseInternal(container);

            BeforeRequest += ctx =>
            {
                var staticFileExtensions =
                    new Dictionary<string, string>
                        {
                            { "jpg", "image/jpg" },
                            { "png", "image/png" },
                            { "css", "text/css" },
                            { "js",  "text/javascript" }
                        };

                var requestedExtension =
                    Path.GetExtension(ctx.Request.Uri);

                if (!string.IsNullOrEmpty(requestedExtension))
                {
                    var extensionWithoutDot =
                        requestedExtension.Substring(1);

                    if (staticFileExtensions.Keys.Any(x => x.Equals(extensionWithoutDot, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        var filePath = "Public" + ctx.Request.Uri.Replace('/', '\\');

                        return new GenericFileResponse(filePath, staticFileExtensions[extensionWithoutDot]);
                    }
                }

                return null;
            };
        }

        public INancyEngine GetEngine()
        {
            return base.GetEngine();
        }

        #endregion
    }
}
