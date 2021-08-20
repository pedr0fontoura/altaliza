import { useState, useCallback } from 'react';

import { Container, Option, Text, Description } from './styles';

export interface IOption {
  id: string;
  text: string;
  description: string;
}

interface IOptionsPickerProps {
  options: IOption[];
  onOptionPick?: (id: string) => void;
}

const OptionsPicker = ({ options, onOptionPick }: IOptionsPickerProps) => {
  const [activeOption, setActiveOption] = useState<number>();

  const selectOption = useCallback(
    (index: number) => {
      setActiveOption(index);

      if (onOptionPick) {
        onOptionPick(options[index].id);
      }
    },
    [setActiveOption, options],
  );

  return (
    <Container>
      {options.map(({ id, text, description }, index) => (
        <Option key={id} active={activeOption === index} onClick={() => selectOption(index)}>
          <Text>{text}</Text>
          <Description>{description}</Description>
        </Option>
      ))}
    </Container>
  );
};

export default OptionsPicker;
