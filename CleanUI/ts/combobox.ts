export function comboboxInitializeKeyboard(id: string, listboxId: string) {
	const combobox = document.getElementById(id);
	const listbox = document.getElementById(listboxId);

	if (!combobox || !listbox) {
		throw new Error(`Could not find combobox and/or listbox using ID: ${id}`);
	}

	combobox.addEventListener('click', function (event) {
		event.preventDefault();
		event.stopPropagation();

		listbox.showPopover();
		(listbox.firstElementChild as HTMLElement).focus();
	});

	combobox.addEventListener('keydown', function (event) {
		if (event.ctrlKey || event.shiftKey) {
			return;
		}

		const handled = [
			'Down', 'ArrowDown',
		].includes(event.key);

		switch (event.key) {
			case 'Down':
			case 'ArrowDown':
				listbox.showPopover();

				if (!event.altKey) {
					(listbox.firstElementChild as HTMLElement).focus();
				}

				break;
		}

		if (handled) {
			event.preventDefault();
			event.stopPropagation();
		}
	});

	listbox.addEventListener('toggle', function (event) {
		const open = event.newState === 'open';

		combobox.ariaExpanded = open.toString();
	});

	listbox.addEventListener('keydown', function (event) {
		if (event.ctrlKey || event.shiftKey) {
			return;
		}

		const handled = [
			'Down', 'ArrowDown',
			'Up', 'ArrowUp',
			'Home', 'End',
			'Enter', 'Tab',
			// Add `Space` to prevent instantly scrolling down using the space-bar.
			'Space'
		].includes(event.key);

		switch (event.key) {
			case 'Down':
			case 'ArrowDown': {
				const nextElement = getNextOption(+1);
				nextElement.focus();
				break;
			}

			case 'Up':
			case 'ArrowUp': {
				if (event.altKey) {
					listbox.hidePopover();
					combobox.focus();
				} else {
					const nextElement = getNextOption(-1);
					nextElement.focus();
				}
				break;
			}

			case 'Home':
				selectOption(listbox.children[0]);
				break;

			case 'End':
				selectOption(listbox.children[listbox.childElementCount - 1]);
				break;

			case 'Tab':
			case 'Enter':
				selectOption(document.activeElement);
				break;
		}

		if (handled) {
			event.preventDefault();
			event.stopPropagation();
		}

		function getNextOption(mod: number): HTMLElement {
			const current = document.activeElement as HTMLElement;

			if (!current) {
				return;
			}

			const idx = Array.prototype.indexOf.call(listbox.children, current);

			let next = idx + mod;

			if (next < 0) {
				next = listbox.childElementCount - 1;
			} else if (next >= listbox.childElementCount) {
				next = 0;
			}

			return listbox.children.item(next) as HTMLElement;
		}

		function selectOption(element: Element) {
			// Trigger a `click` event so the server's `onclick` handler gets called.
			if (element instanceof HTMLLIElement) {
				element.click();
			}
		}
	});
}
