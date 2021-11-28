---
external help file: Itertools.dll-Help.xml
Module Name: Itertools
online version:
schema: 2.0.0
---

# Take-Item

## SYNOPSIS
Takes items from the pipeline.

## SYNTAX

### number (Default)
```
Take-Item [-N] <Int32> [-Last] -Input <Object> [<CommonParameters>]
```

### script
```
Take-Item [-While] <ScriptBlock> -Input <Object> [<CommonParameters>]
```

## DESCRIPTION
Takes items from the pipeline, ignoring the rest.

## EXAMPLES

### Example 1
This example takes numbers from the pipeline until it encounters a 2 digit number.

```powershell
PS C:\> 1..20 | Take-Item { "$_".length -ne 2 }
```

```
1
2
3
4
5
6
7
8
9
```

## PARAMETERS

### -Input
The input from the pipeline.

```yaml
Type: Object
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Last
Take last N items instead.

```yaml
Type: SwitchParameter
Parameter Sets: number
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -N
How many items to take.

```yaml
Type: Int32
Parameter Sets: number
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -While
Take items while this script block evaluates to true.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Object

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS
