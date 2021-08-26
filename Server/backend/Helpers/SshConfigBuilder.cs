﻿using ScalableTeaching.Data;
using ScalableTeaching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalableTeaching.Helpers
{
    public class SshConfigBuilder
    {
        private readonly VmDeploymentContext _context;

        public SshConfigBuilder(VmDeploymentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Generates a configuration string for an ssh config
        /// </summary>
        /// <param name="assignment">The credential object representing a credential pair for a user</param>
        /// <param name="includeClassName">True indicates that the host name will be prefixed with the short version of the course name</param>
        /// <returns>Config string for specified machine</returns>
        public async Task<string> GetMachineCredentialStringAsync(Machine machine, string username, bool includeClassName = false)
        {
           return await Task.Run<string>(() =>
            {
                var hostName = machine.HostName;
                var course = machine.Course;
                List<int> ports = machine.Ports;

                StringBuilder credentialBuilder = new();

                //Insert host name string
                credentialBuilder.Append("Host ");
                if (includeClassName)
                {
                    credentialBuilder.Append(course.ShortCourseName);
                }
                credentialBuilder.Append(hostName).Append('\n');

                //Insert HostName url string
                credentialBuilder.Append('\t').Append("HostName ").Append(hostName).Append('\n');

                //Insert Username for the machine
                credentialBuilder.Append('\t').Append("User").Append(username).Append('\n');

                //Insert strings for portnumbers
                foreach (var port in ports)
                {
                    credentialBuilder.Append('\t').Append("LocalForward ").Append(port).Append("127.0.0.1:").Append(port).Append('\n');
                }

                //Insert Identityfile string
                credentialBuilder.Append('\t').Append("IdentityFile ").Append("~/.ssh/id_rsa_scalable_").Append(username);

                return credentialBuilder.ToString();
            });

        }

        public void BuildAuthorisedKeysFile(Machine machine)
        {
            var assignments = _context.MachineAssignments.Where(assignment =>
                assignment.MachineID == machine.MachineID);
            //TODO : Continue this
        }
    }
}
