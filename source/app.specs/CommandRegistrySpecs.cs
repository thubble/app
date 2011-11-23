﻿using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(CommandRegistry))]
  public class CommandRegistrySpecs
  {
    public abstract class concern : Observes<IFindCommands,
                                      CommandRegistry>
    {
    }

    public class when_finding_a_command_to_process_a_request : concern
    {
      public class and_it_has_the_command 
      {
        Establish c = () =>
        {
          all_commands = Enumerable.Range(1,100).Select(x => fake.an<IProcessOneRequest>()).ToList();
          request = fake.an<IContainRequestInformation>();
          the_command_that_can_process = fake.an<IProcessOneRequest>();

          all_commands.Add(the_command_that_can_process);

          the_command_that_can_process.setup(x => x.can_handle(request)).Return(true);

          depends.on<IEnumerable<IProcessOneRequest>>(all_commands);
        };

        Because b = () =>
          result = sut.get_the_command_that_can_process(request);


      	It should_return_the_command_to_the_caller = () =>
      		result.ShouldEqual(the_command_that_can_process);

        static IProcessOneRequest the_command_that_can_process;
        static IContainRequestInformation request;
        static List<IProcessOneRequest> all_commands;
      }

      public class and_it_does_not_have_the_command 
      {
        Establish c = () =>
        {
          all_commands = Enumerable.Range(1,100).Select(x => fake.an<IProcessOneRequest>()).ToList();
          special_case = depends.on<IProcessOneRequest>();
          request = fake.an<IContainRequestInformation>();
          depends.on<IEnumerable<IProcessOneRequest>>(all_commands);
        };

        Because b = () =>
          result = sut.get_the_command_that_can_process(request);


      	It should_return_the_special_case = () =>
      		result.ShouldEqual(special_case);

        static IContainRequestInformation request;
        static List<IProcessOneRequest> all_commands;
        static IProcessOneRequest special_case;
      }

      static IProcessOneRequest result;
    }
  }
}