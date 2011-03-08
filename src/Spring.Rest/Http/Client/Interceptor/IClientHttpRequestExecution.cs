﻿#region License

/*
 * Copyright 2002-2011 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;
using System.IO;

namespace Spring.Http.Client.Interceptor
{
    /// <summary>
    /// Represents the context of a client-side HTTP request execution, 
    /// given to an interceptor.
    /// </summary>
    /// <seealso cref="IClientHttpRequestInterceptor"/>
    /// <author>Arjen Poutsma</author>
    /// <author>Bruno Baia</author>
    public interface IClientHttpRequestExecution
    {
        /// <summary>
        /// Indicates whether the request execution is asynchrone.
        /// </summary>
        bool IsAsync { get; }

        /// <summary>
        /// Gets the HTTP method of the request.
        /// </summary>
        HttpMethod Method { get; }

        /// <summary>
        /// Gets the URI of the request.
        /// </summary>
        Uri Uri { get; }

        /// <summary>
        /// Gets the message headers.
        /// </summary>
        HttpHeaders Headers { get; }

        /// <summary>
        /// Gets or sets the delegate that writes the body message as a stream.
        /// </summary>
        Action<Stream> Body { get;  set; }

        /// <summary>
        /// Execute the request with the current context.
        /// </summary>
        /// <remarks>
        /// Used to invoke the next interceptor in the interceptor chain, 
        /// or - if the calling interceptor is last - execute the request itself.
        /// </remarks>
        /// <seealso cref="M:Execute(Action{IClientHttpResponse} requestExecuted)"/>
        void Execute();

        /// <summary>
        /// Execute the request with the current context.
        /// </summary>
        /// <remarks>
        /// Used to invoke the next interceptor in the interceptor chain, 
        /// or - if the calling interceptor is last - execute the request itself.
        /// </remarks>
        /// <param name="requestExecuted">
        /// The <see cref="Action{IClientHttpResponse}"/> to perform when the execution completes.
        /// </param>
        /// <seealso cref="M:Execute()"/>
        void Execute(Action<IClientHttpResponse> requestExecuted);
    }
}
