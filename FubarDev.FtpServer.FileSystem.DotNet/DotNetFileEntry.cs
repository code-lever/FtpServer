﻿//-----------------------------------------------------------------------
// <copyright file="DotNetFileEntry.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System;
using System.IO;

using FubarDev.FtpServer.FileSystem.Generic;

namespace FubarDev.FtpServer.FileSystem.DotNet
{
    /// <summary>
    /// A <see cref="IUnixFileEntry"/> implementation for the standard
    /// .NET file system functionality.
    /// </summary>
    public class DotNetFileEntry : IUnixFileEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetFileEntry"/> class.
        /// </summary>
        /// <param name="info">The <see cref="FileInfo"/> to extract the information from</param>
        public DotNetFileEntry(FileInfo info)
        {
            Info = info;
            LastWriteTime = new DateTimeOffset(Info.LastWriteTime);
            var accessMode = new GenericAccessMode(true, true, true);
            Permissions = new GenericUnixPermissions(accessMode, accessMode, accessMode);
        }

        /// <summary>
        /// Gets the underlying <see cref="FileInfo"/>
        /// </summary>
        public FileInfo Info { get; }

        /// <inheritdoc/>
        public string Name => Info.Name;

        /// <inheritdoc/>
        public IUnixPermissions Permissions { get; }

        /// <inheritdoc/>
        public DateTimeOffset? LastWriteTime { get; }

        /// <inheritdoc/>
        public long NumberOfLinks => 1;

        /// <inheritdoc/>
        public string Owner => "owner";

        /// <inheritdoc/>
        public string Group => "group";

        /// <inheritdoc/>
        public long Size => Info.Length;
    }
}
