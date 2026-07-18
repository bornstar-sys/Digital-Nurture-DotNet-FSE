# Notes - Mocking with Moq

## Mocking, Isolation, and Test Doubles

A test double is any fake object used in place of a real one during testing.
Mocking is creating a test double that you can configure to behave a
certain way (return specific values, verify it was called, etc), so you can
test your code without needing the real dependency (database, mail server,
file system) to actually exist or run during the test.

Isolation means the test only checks the one piece of code you care about,
without the result depending on outside systems being available or working.

## Mock vs Fake vs Stub

- Stub: a simple object that returns fixed/canned answers when called, with
  no real logic behind it.
- Fake: a working but simplified implementation (e.g. an in-memory list
  standing in for a real database).
- Mock: like a stub, but you can also verify how it was used afterward (was
  this method called, how many times, with what arguments).

Moq covers stub and mock-style behavior - it lets you both set up canned
return values and check that calls happened the way you expected.

## How Mocking Helps TDD

TDD (Test-Driven Development) means writing the test before the actual
code. This only works smoothly if tests can run fast and without needing a
fully working system around them. Mocking dependencies means you can write
and run tests for a class before its dependencies (database, mail service,
etc) are even built yet, since the test just uses a fake version of them.

## Dependency Injection

Dependency Injection (DI) means a class receives the things it depends on
from outside, instead of creating them itself internally.

- Constructor Injection: the dependency is passed in through the
  constructor (used in CustomerComm - IMailSender comes in as a constructor
  parameter).
- Method Injection: the dependency is passed in as a parameter to a specific
  method instead of the whole class (used in Player.RegisterNewPlayer -
  IPlayerMapper is an optional method parameter).

This matters for testing because if a class creates its own dependency
internally, there's no way to swap in a mock during a test. If it receives
the dependency from outside, a test can just hand it a mock instead of the
real thing.

## Why These Three Exercises Needed Refactoring First

In all three cases, the original code couldn't be unit tested as-is:
- MailSender directly called a real SMTP server inside the method
- DirectoryExplorer used Directory.GetFiles(), a static method, which Moq
  can't mock directly
- PlayerMapper directly opened a real SQL connection inside the method

The fix in each case was the same: wrap the real implementation behind an
interface, and have the class under test depend on the interface instead
of the concrete class directly. Once that's done, a mock of the interface
can be substituted in during tests, and the actual database/mail
server/file system is never touched while testing.