window.Modal = {
	open(id) {
		const element = document.getElementById(id) as HTMLDialogElement;

		if (!(element instanceof HTMLDialogElement)) {
			throw new Error(`[CleanUI] Element with id '${id}' was either not found or isn't a valid HTMLDialogElement.`);
		}

		let initial = true;

		element.showModal();

		window.addEventListener('click', clickHandler);
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
				
				element.close();
			}
		}

		function closeHandler() {
			window.removeEventListener('click', clickHandler);
			element.removeEventListener('close', closeHandler);
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
