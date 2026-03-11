window.Modal = {
	open(id) {
		const element = document.getElementById(id) as HTMLDialogElement;

		if (!(element instanceof HTMLDialogElement)) {
			throw new Error(`[CleanUI] Element with id '${id}' was either not found or isn't a valid HTMLDialogElement.`);
		}

		const closable = !element.dataset || (element.dataset['closable'] !== 'false');

		let initial = true;

		element.showModal();

		if (closable) {
			window.addEventListener('click', clickHandler);
		} else {
			window.addEventListener('keydown', keyDownHandler);
		}

		element.addEventListener('close', closeHandler);

		function clickHandler(event: PointerEvent) {
			if (initial) {
				initial = false;
				return;
			}

			const rect = element.getBoundingClientRect();
			const clickedInDialog = (rect.top <= event.clientY) && (event.clientY <= rect.top + rect.height) &&
				(rect.left <= event.clientX) && (event.clientX <= rect.left + rect.width);

			if (!clickedInDialog) {
				event.preventDefault();
				event.stopPropagation();

				element.requestClose();
			}
		}

		function keyDownHandler(event: KeyboardEvent) {
			if (['Escape', 'Esc'].includes(event.key)) {
				event.preventDefault();
				event.stopPropagation();
			}
		}

		function closeHandler(event: Event) {
			window.removeEventListener('click', clickHandler);
			element.removeEventListener('close', closeHandler);
			window.removeEventListener('keydown', keyDownHandler);
		}
	},

	close(id) {
		const element = document.getElementById(id);

		if (!(element instanceof HTMLDialogElement)) {
			throw new Error(`[CleanUI] Element with id '${id}' was either not found or isn't a valid HTMLDialogElement.`);
		}

		element.close();
	},
};
