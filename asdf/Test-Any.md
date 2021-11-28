---
external help file: Itertools.dll-Help.xml
Module Name: Itertools
online version:
schema: 2.0.0
---

# Test-Any

## SYNOPSIS
Tests if any item from the pipeline fits within the criteria given.

## SYNTAX

### script (Default)
```
Test-Any [-Predicate] <ScriptBlock> [-Input] <Object> [<CommonParameters>]
```

### eq
```
Test-Any [-Value] <Object> [-Input] <Object> [<CommonParameters>]
```

## DESCRIPTION
Checks if any item from the pipeline satisfies the given criteria.
The criteria can be a script block returning true/false or a value that will be checked for equality.
The script block won't be executed after it returns true.

## EXAMPLES

### Example 1
```
PS C:\> 33..53 | Test-Any { $_ % 5 -eq 0 }

True
```

## PARAMETERS

### -Input
The input from the pipeline.

```yaml
Type: Object
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Predicate
A predicate that evaluates to a bool.

```yaml
Type: ScriptBlock
Parameter Sets: script
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
Test that any value from the pipeline is equal to this one.

```yaml
Type: Object
Parameter Sets: eq
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Object
## OUTPUTS

### System.Boolean
## NOTES

## RELATED LINKS
