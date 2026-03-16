export {};

declare global {
	interface Window {
		Modal: {
			open(id: string): void;
			close(id: string): void;
		},
		Tooltip: {
			registerAll(): void;
			register(tooltip: HTMLElement): void;
			show(id: string): void;
			hide(id: string): void;
		},
		Blazor: Blazor,
	}

	interface Blazor {
		addEventListener(type: 'enhancedload', listener: (ev: Event) => any): void;
	}

	const Blazor: Blazor;
}
