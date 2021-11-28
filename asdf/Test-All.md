---
external help file: Itertools.dll-Help.xml
Module Name: Itertools
online version:
schema: 2.0.0
---

# Test-All

## SYNOPSIS
Asserts that every item from the pipeline fits within a criteria.

## SYNTAX

### script (Default)
```
Test-All [-Predicate] <ScriptBlock> [-Input] <Object> [<CommonParameters>]
```

### eq
```
Test-All [-Value] <Object> [-Input] <Object> [<CommonParameters>]
```

## DESCRIPTION
Asserts that every item from the pipeline fits within a criteria.

The criteria can be a script block returning true/false or a value that will be checked for equality.

## EXAMPLES

### Example 1
```
PS C:\> $text = "banana is good
>> banana is life
>> my brother was beaten badly with a banana wielding man"
>>
PS C:\> $text.split("`n") | Test-All { $_.contains("banana") }

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
Test that all values from the pipeline are equal to this one.

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
