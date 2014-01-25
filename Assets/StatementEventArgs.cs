using System;

public class StatementEventArgs : EventArgs
{
  Statement statement;

  public Statement Statement {
    get {
      return statement;
    }
  }

  public StatementEventArgs (Statement statementMade)
  {
    statement = statementMade;
  }
}

