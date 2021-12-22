---
external help file: Itertools.dll-Help.xml
Module Name: Itertools
online version:
schema: 2.0.0
---

# Fold-Pipe

## SYNOPSIS
Applies a reducing operation to every item in the pipeline, yielding a single value.

## SYNTAX

```
Fold-Pipe -InputObject <Object> [-ScriptBlock] <ScriptBlock> [-InitialValue <Object>] [<CommonParameters>]
```

## DESCRIPTION
Applies an operation to each item in the pipeline, reducing it down to a single value.
This is the equivalent of a flatmap / fold.

The script block gets to access the pipeline item with the $_ variable and the result of the previous call as $__ (also set as $args[0])

## EXAMPLES

### Example 1
```powershell
1..5 | Fold-Pipe { $_ * $__ }
120
```

This example calculates the factorial of 5.

## PARAMETERS

### -InitialValue
An optional initial value.

```yaml
Type: Object
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -ScriptBlock
A script block that takes 1 argument (the last item calculated) and the access to the pipeline ($_).

```yaml
Type: ScriptBlock
Parameter Sets: (All)
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

### System.Object

## NOTES

## RELATED LINKS
