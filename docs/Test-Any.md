---
external help file: Itertools.dll-Help.xml
Module Name: Itertools
online version:
schema: 2.0.0
---

# Test-Any

## SYNOPSIS
Tests if any item from the pipeline satisfies a predicate.

## SYNTAX

### script (Default)
```
Test-Any -InputObject <Object> [-Predicate] <ScriptBlock> [<CommonParameters>]
```

### eq
```
Test-Any -InputObject <Object> [-Value] <Object> [<CommonParameters>]
```

## DESCRIPTION
Tests if any item from the pipeline satisfies a predicate.

## EXAMPLES

### Example 1
```powershell
23..66 | Test-Any 50
True
32..66 | Test-Any { $_ % 2 -eq 0 }
True
```

<None>

## PARAMETERS

### -InputObject
The input object.

```yaml
Type: Object
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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
